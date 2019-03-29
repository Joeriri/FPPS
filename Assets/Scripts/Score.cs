using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score = 0f;

    void Start()
    {
        score = 0f;
    }

    public void AddPoints(float amount)
    {
        score += amount;
    }
}
