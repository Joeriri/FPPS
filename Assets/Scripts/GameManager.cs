using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = Instance == null ? this : Instance;
    }

    void Start()
    {

    }
}
