using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [HideInInspector] public bool gameOver = false;

    [SerializeField] private Image blackScreen;
    [SerializeField] private Image damageScreen;
    private Player player;
    private AudioManager am;

    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
        player = FindObjectOfType<Player>();
        am = FindObjectOfType<AudioManager>();
    }

    private void Start()
    {
        StartCoroutine(FadeToClear());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            DamageEffect();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        StartCoroutine(FadeToBlack());
        Debug.Log("Game Over!");
        am.Play("GameOver");
    }

    public void DamageEffect()
    {
        StartCoroutine(DamageEffectRoutine());
        am.Play("Player_damage");
    }

    IEnumerator DamageEffectRoutine()
    {
        for (float i = 0.0f; i < 1.0f * player.damageEffectDuration; i += Time.deltaTime)
        {
            damageScreen.color = Color.Lerp(Color.clear, player.damageColor, Mathf.Sin(i * 3f / player.damageEffectDuration)); // t * 3f omdat radialen.
            yield return null;
        }
    }

    IEnumerator FadeToBlack()
    {
        for (float i = 0f; i < 1f; i += Time.deltaTime)
        {
            blackScreen.color = Color.Lerp(Color.clear, Color.black, i);
            yield return null;
        }
    }

    IEnumerator FadeToClear()
    {
        for (float i = 0f; i < 1f; i += Time.deltaTime)
        {
            blackScreen.color = Color.Lerp(Color.black, Color.clear, i);
            yield return null;
        }
    }

    public void PlaySound(string name)
    {
        am.Play(name);
    }
}
