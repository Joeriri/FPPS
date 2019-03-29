using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private Finish finish;

    private void Awake()
    {
        finish = GetComponentInParent<Finish>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null && finish.activated) //Check if the collider is the player.
        {
            GameManager.Instance.LevelCompleted();
        }
    }
}