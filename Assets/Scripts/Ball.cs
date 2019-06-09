using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector] public bool deadly = false;
    [SerializeField] private float damagePoints = 1f;

    // Audio
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] hitClips;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

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

        audioSource.clip = hitClips[ (Random.Range(0, hitClips.Length)) ];
        audioSource.Play();
    }

    public void BecomeDeadly()
    {
        deadly = true;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
    }
}
