using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private Image blackScreen;
    [SerializeField] private Image damageScreen;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text scoreTextBG;
    [SerializeField] private Text healthText;
    [SerializeField] private Text healthTextBG;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text highScoreTextBG;

    [SerializeField] private Color damageColor = new Color(255, 37, 37, 100);

    public void FadeToBlack()
    {
        StartCoroutine(FadeToBlackRoutine());
    }

    public void FadeToClear()
    {
        StartCoroutine(FadeToClearRoutine());
    }

    IEnumerator FadeToBlackRoutine()
    {
        for (float i = 0f; i < 1f; i += Time.deltaTime)
        {
            blackScreen.color = Color.Lerp(Color.clear, Color.black, i);
            yield return null;
        }

        GameManager.Instance.OnFadeToBlackFinished();
    }

    IEnumerator FadeToClearRoutine()
    {
        for (float i = 0f; i < 1f; i += Time.deltaTime)
        {
            blackScreen.color = Color.Lerp(Color.black, Color.clear, i);
            yield return null;
        }
    }

    public void DamageEffect()
    {
        StartCoroutine(DamageEffectRoutine());
    }

    IEnumerator DamageEffectRoutine()
    {
        for (float i = 0.0f; i < 1.0f * 0.2f; i += Time.deltaTime)
        {
            damageScreen.color = Color.Lerp(Color.clear, damageColor, Mathf.Sin(i * 3f / 0.2f)); // t * 3f omdat radialen.
            yield return null;
        }
    }

    public void UpdateScoreUI(string text)
    {
        scoreText.text = text;
        scoreTextBG.text = text;
    }

    public void UpdateHealthUI(string text)
    {
        healthText.text = text;
        healthTextBG.text = text;
    }

    public void UpdateHighScoreUI(string text)
    {
        highScoreText.text = text;
        highScoreTextBG.text = text;
    }
}
