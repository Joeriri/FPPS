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

    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            DamageEffect(1f);
        }
    }

    public void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over!");
    }

    public void DamageEffect(float duration)
    {
        StartCoroutine(DamageEffectRoutine(duration));
    }


    IEnumerator DamageEffectRoutine(float duration)
    {
        float t = 0;
        float step = 1f / duration;
        while (t < 1)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            t += Time.deltaTime;
            damageScreen.color = Color.Lerp(Color.clear, player.damageColor, Mathf.Sin(t * 3f)); // t * 3f omdat radialen.
            Debug.Log(t);
        }
    }
}
