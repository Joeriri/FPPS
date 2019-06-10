using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [HideInInspector] public int score;
    [HideInInspector] public int highScore;
    private LevelUI levelUI;

    private void Awake()
    {
        levelUI = FindObjectOfType<LevelUI>();
    }

    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        levelUI.UpdateScoreUI(score.ToString());
        levelUI.UpdateHighScoreUI("HI: " + highScore.ToString());
    }

    public void AddPoints(int amount)
    {
        score += amount;
        PlayerPrefs.SetInt("Score", score);
        levelUI.UpdateScoreUI(score.ToString());

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            levelUI.UpdateHighScoreUI("HI: " + highScore.ToString());
        }
    }
}
