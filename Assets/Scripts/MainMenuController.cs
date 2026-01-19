using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public PauseController pauseController;

    public GameObject pausePanel;

    void Start()
    {
        mainMenuPanel.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (pauseController != null)
        {
            pauseController.enabled = false;
        }
    }

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        pausePanel.SetActive(false);

        if (pauseController != null)
        {
            pauseController.enabled = true;
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
