using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3(0, 1, 0);
    public GameObject ball;

    private void Update()
    {
        if (Input.GetKeyDown("Q"))
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        Instantiate(ball, transform.position + offset, transform.rotation);
    }
}
