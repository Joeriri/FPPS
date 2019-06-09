using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float health = 3f;
    [SerializeField] private float damageEffectDuration = 1f;
    public Color damageColor = new Color(255, 37, 37, 100);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damagePoints)
    {
        health -= damagePoints;
        GameManager.Instance.DamageEffect(damageEffectDuration);

        // De speler gaat dood
        if (health <= 0 && GameManager.Instance.gameOver != true)
        {
            GameManager.Instance.GameOver();
        }
    }
}
