using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score = 0f;

    public GameObject scoreText;

    void Start()
    {
        score = 0f;
    }

    void Update()
    {
        Text textCom = scoreText.GetComponent<Text>();
        textCom.text = "Score: " + score.ToString();
    }

    public void AddPoints(float amount)
    {
        score += amount;
    }
}
