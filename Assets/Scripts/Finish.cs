using UnityEngine;

public class Finish : MonoBehaviour
{
    public Score score;
    public bool activated = false;
    [SerializeField] private float pointsNeeded = 0f;
    public Material activeMat;

    void Start()
    {
        
    }

    void Update()
    {
        if (score.score >= pointsNeeded && !activated)
        {
            activated = true;
            GetComponent<Renderer>().material = activeMat;
        }
    }
}

