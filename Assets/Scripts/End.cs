using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        scoreText.text = "SCORE: " + PlayerPrefs.GetInt("Score").ToString();
        highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void Quit()
    {
        Application.Quit();
        PlayerPrefs.DeleteAll();
        Debug.Log("Game Quit!");
    }

    public void Restart()
    {
        PlayerPrefs.DeleteKey("Score");
        SceneManager.LoadScene("Level");
    }
}
