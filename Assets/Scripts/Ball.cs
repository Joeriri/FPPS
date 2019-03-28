using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Laser tempLaser = collision.collider.GetComponent<Laser>();
        if (tempLaser != null)
        {
            Destroy(gameObject);
        }
    }
}
