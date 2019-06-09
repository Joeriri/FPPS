using UnityEngine;

public class Target : MonoBehaviour
{
    public Score score;
    [SerializeField] private int points = 1;
    public Material hitMaterial;
    private bool activated = false;
    
    void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<Ball>() != null && !activated) //If the collider is a Ball and target is not activated yet, add points, change mat and activate.
        {
            score.AddPoints(points);
            GetComponentInParent<Renderer>().material = hitMaterial;
            activated = true;
        }
    }
}
