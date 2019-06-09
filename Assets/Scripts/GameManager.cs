using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector] public bool gameOver = false;
    private Player player;
    private AudioManager am;
    private LevelUI levelUI;

    private void Awake()
    {
        Instance = Instance == null ? this : Instance;

        player = FindObjectOfType<Player>();
        am = FindObjectOfType<AudioManager>();
        levelUI = FindObjectOfType<LevelUI>();
    }

    private void Start()
    {
        levelUI.FadeToClear();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            player.Damage(1f);
        }
    }

    public void GameOver()
    {
        gameOver = true;
        am.Play("GameOver");
        levelUI.FadeToBlack();
        Debug.Log("Game Over!");
    }

    public void OnFadeToBlackFinished()
    {
        SceneManager.LoadScene("End");
    }

    public void PlaySound(string name)
    {
        am.Play(name);
    }
}
