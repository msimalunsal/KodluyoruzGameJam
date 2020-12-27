
public class MainMenuPanel : Panel
{
    void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnGameStart.AddListener(HidePanel);
        EventManager.OnGameOver.AddListener(ShowPanel);
    }

    void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnGameStart.RemoveListener(HidePanel);
        EventManager.OnGameOver.RemoveListener(ShowPanel);

    }
}
