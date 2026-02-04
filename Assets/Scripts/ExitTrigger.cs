using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    public GameObject victoryPanel;
    public FPSController fpsController;
    public GameMode gameMode;

     private void Start()
    {
        if (FPSController.instance != null)
        {
            fpsController = FPSController.instance;
            gameMode = fpsController.gameMode;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameMode != GameMode.Classic)
        return;
        if(other.CompareTag("Player") && fpsController != null)
        {
            Time.timeScale = 0f;
            fpsController.gameEnded = true;
            if(victoryPanel != null) victoryPanel.SetActive(true);
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

