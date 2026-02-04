using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameMode gameMode;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetClassicMode()
    {
        gameMode = GameMode.Classic;
    }

    public void SetEndlessMode()
    {
        gameMode = GameMode.Endless;
    }
}
