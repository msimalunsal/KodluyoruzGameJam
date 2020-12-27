using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitManager : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return SceneManager.LoadSceneAsync(PlayerPrefs.GetString("UI", "UI"), LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync(PlayerPrefs.GetString("LastLevel", "Game"), LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(PlayerPrefs.GetString("LastLevel", "Game")));
        Destroy(gameObject);
    }
}
