using UnityEngine;
using System.Collections;

//DISCLAIMER: Code from Nathan

public class Ring : MonoBehaviour
{
    public Score score;
    [SerializeField]
    private float points = 1f;
    public Material hitMaterial;
    private bool activated = false;

    //Front and back plane triggers.
    public RingHitbox front;
    public RingHitbox back;
    
    void Update()
    {
        if (front.HIT && back.HIT) //If both the front and back trigger are hit, set them to not hit and add points.
        {
            front.HIT = back.HIT = false;

            if (!activated)
            {
                score.AddPoints(points);
                GetComponent<Renderer>().material = hitMaterial;
                activated = true;
            }
            
        }
        else if (front.HIT || back.HIT) //If only one trigger was hit, wait for the other to be hit. If the other trigger didn't get hit the ball didn't go through, so set both to not hit.
        {
            StartCoroutine(WaitForDisable());
        }
    }

    private IEnumerator WaitForDisable ()
    {
        yield return new WaitForSeconds(.2f);
        front.HIT = back.HIT = false;

    }
}
