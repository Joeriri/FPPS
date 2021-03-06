﻿using UnityEngine;
using System.Collections;

// Mix tussen code van Nathan en mij

public class Ring : MonoBehaviour
{
    [SerializeField] private RingHitbox front;
    [SerializeField] private RingHitbox back;
    private bool activated = false;
    private Score score;
    [SerializeField] private int points = 1;
    private HoopManager hoopManager;
    private AudioSource scoreSound;
    
    private void Awake()
    {
        score = FindObjectOfType<Score>();
        hoopManager = FindObjectOfType<HoopManager>();
        scoreSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (front.HIT && back.HIT) // Controleer of door zowel back als door front een object gegaan is,
        {
            if (front.passenger == back.passenger) // Controleer of dat hetzelfde object was,
            {
                Ball ball = front.passenger.GetComponent<Ball>(); // Controleer of het een Ball was.
                if (ball != null && !ball.deadly && !activated)
                {
                    // Maak de bal dodelijk.
                    ball.BecomeDeadly();

                    // Geef punten en vernietig de Ring.
                    score.AddPoints(points);
                    activated = true;
                    StartCoroutine(DestroyRing());
                    scoreSound.Play();
                }
            }

            // Deactiveer back en front.
            DisableRingHitboxes();
        }
        else if (front.HIT || back.HIT) // If only one trigger was hit, wait for the other to be hit. If the other trigger didn't get hit the ball didn't go through, so set both to not hit.
        {
            StartCoroutine(WaitForDisable());
        }  
    }

    private IEnumerator WaitForDisable ()
    {
        yield return new WaitForSeconds(.2f);
        DisableRingHitboxes();
    }

    private void DisableRingHitboxes()
    {
        front.HIT = back.HIT = false;
        front.passenger = back.passenger = null;
    }



    private IEnumerator DestroyRing()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        hoopManager.CreateHoop();
    }
}
