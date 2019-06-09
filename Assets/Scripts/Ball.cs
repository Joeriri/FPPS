using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector] public bool deadly = false;
    [SerializeField] private float damagePoints = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        Player tempPlayer = collision.collider.GetComponent<Player>();
        if (tempPlayer != null)
        {
            if (deadly)
            {
                tempPlayer.Damage(damagePoints);
            }
        }
    }

    public void BecomeDeadly()
    {
        deadly = true;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
    }
}
