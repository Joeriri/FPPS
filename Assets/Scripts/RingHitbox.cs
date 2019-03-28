using UnityEngine;

//DISCLAIMER: Code from Nathan

public class RingHitbox : MonoBehaviour
{

    private bool hit = false;

    private void OnTriggerEnter(Collider coll) //If a trigger gets hit, set hit to true.
    {
        HIT = true;
    }
    public bool HIT
    {
        get { return hit; }
        set { hit = value; }
    }
}
