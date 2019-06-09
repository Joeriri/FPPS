using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score = 0f;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text scoreTextBG;

    void Start()
    {
        score = 0f;
    }

    public void AddPoints(float amount)
    {
        score += amount;
        scoreText.text = score.ToString();
        scoreTextBG.text = scoreText.text;
    }
}
