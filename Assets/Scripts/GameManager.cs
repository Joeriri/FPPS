using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public LevelTransition levelTransition;
    bool levelHasEnded = false;

    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
    }

    public void LevelCompleted()
    {
        if (!levelHasEnded)
        {
            levelHasEnded = true;
            levelTransition.FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void RestartLevel()
    {
        if (!levelHasEnded)
        {
            levelHasEnded = true;
            levelTransition.FadeToLevel(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
