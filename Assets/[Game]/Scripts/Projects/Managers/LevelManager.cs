using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public Level level;
    public LevelData LevelData;

    //Public Properities about current Level
    public Level CurrentLevel { get { return (LevelData.Levels[LevelIndex]); } }
    //public DifficulityData DifficulityData { get { return (LevelData.Levels[LevelIndex].DifficulityData[DifficulityIndex]); } }
    
    private bool isLevelStarted;

    public bool IsLevelStarted { get { return isLevelStarted; } private set { isLevelStarted = value; } }

    public int LevelIndex
    {
        get
        {
            return PlayerPrefs.GetInt("LastLevel", 0);
        }
        set
        {
            if (value >= LevelData.Levels.Count)
                value = 0;

            PlayerPrefs.SetInt("LastLevel", value);
        }
    }

    //public int DifficulityIndex { get; set; }

    public void StartLevel()
    {
        if (IsLevelStarted)
            return;

        IsLevelStarted = true;
        EventManager.OnLevelStart.Invoke();
    }

    public void FinishLevel()
    {
        if (!IsLevelStarted)
            return;

        IsLevelStarted = false;
        EventManager.OnLevelFinish.Invoke();
    }

    #region GameOver
    private void OnEnable()
    {
        EventManager.OnGameOver.AddListener(GameOver);
    }

    private void OnDisable()
    {
        EventManager.OnGameOver.RemoveListener(GameOver);
    }

    public void GameOver()
    {
        StartCoroutine(LoadNextSceneCo());
    }

    private IEnumerator LoadNextSceneCo()
    {
        //Cach next level build index.
        int buildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Scene initScene = SceneManager.GetSceneAt(0);
        SceneManager.SetActiveScene(initScene);
        //Get how many scenes are loaded.
        int sceneCount = SceneManager.sceneCount;

        //Create list for scenes to be unloaded.
        List<Scene> scenesToBeUnloaded = new List<Scene>();

        //Add scenes to be unloaded to the list
        for (int i = 0; i < sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name.Contains("Game"))
            {
                scenesToBeUnloaded.Add(scene);
            }
        }

        //Unload all scenes that needs to be unloaded.
        foreach (var s in scenesToBeUnloaded)
        {
            yield return SceneManager.UnloadSceneAsync(s.buildIndex);
        }

        //Check if we can load this scene
        if (!Application.CanStreamedLevelBeLoaded(buildIndex))
        {
            //Set it back to default
            buildIndex = 1;
        }


        //Load the scene
        yield return SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
        Scene levelScene = SceneManager.GetSceneByBuildIndex(buildIndex);
        SceneManager.SetActiveScene(levelScene);
        PlayerPrefs.SetString("LastLevel", levelScene.name);
    }
    #endregion
}
