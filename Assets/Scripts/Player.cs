using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float health = 3f;
    public float damageEffectDuration = 1f;
    public Color damageColor = new Color(255, 37, 37, 100);
    private LevelUI levelUI;
    private AudioManager am;

    private void Awake()
    {
        levelUI = FindObjectOfType<LevelUI>();
        am = FindObjectOfType<AudioManager>();
    }

    public void Damage(float damagePoints)
    {
        health -= damagePoints;
        am.Play("PlayerDamage");
        levelUI.DamageEffect();
        levelUI.UpdateHealthUI("HP: " + health.ToString());

        // De speler gaat dood
        if (health <= 0 && GameManager.Instance.gameOver != true)
        {
            GameManager.Instance.GameOver();
        }
    }
}
