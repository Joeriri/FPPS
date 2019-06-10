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

    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

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
        for (float i = 0.0f; i < 1.0f * player.damageEffectDuration; i += Time.deltaTime)
        {
            damageScreen.color = Color.Lerp(Color.clear, player.damageColor, Mathf.Sin(i * 3f / player.damageEffectDuration)); // t * 3f omdat radialen.
            yield return null;
        }
        damageScreen.color = Color.clear;
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
