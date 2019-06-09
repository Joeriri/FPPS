using UnityEngine;

// Mix tussen code van Nathan en mij

public class RingHitbox : MonoBehaviour
{
    private bool hit = false;
    public GameObject passenger;

    private void OnTriggerEnter(Collider coll) //If a trigger gets hit, set hit to true.
    {
        HIT = true;
        passenger = coll.gameObject;
    }

    public bool HIT
    {
        get { return hit; }
        set { hit = value; }
    }
}
