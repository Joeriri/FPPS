using UnityEngine;

public class Target : MonoBehaviour
{
    public Score score;
    [SerializeField] private float points = 1f;
    public Material hitMaterial;
    
    void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<Ball>() != null)
        {
            score.AddPoints(points);
            GetComponentInParent<Renderer>().material = hitMaterial;
        }
    }
}
