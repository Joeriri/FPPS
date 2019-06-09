using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopManager : MonoBehaviour
{
    [SerializeField] private GameObject hoop;
    private GameObject newHoop;
    private Player player;
    
    [SerializeField] private Vector3 size = Vector3.one * 10;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void Start()
    {
        CreateHoop();
    }

    public void CreateHoop()
    {
        var rndX = Random.Range(transform.position.x - size.x/2, transform.position.x + size.x/2);
        var rndY = Random.Range(transform.position.y - size.y/2, transform.position.y + size.y/2);
        var rndZ = Random.Range(transform.position.z - size.z/2, transform.position.z + size.z/2);
        var rndRotY = Random.Range(0, 360);

        newHoop = Instantiate(hoop);
        newHoop.transform.position = new Vector3(rndX, rndY, rndZ);
        newHoop.transform.rotation = Quaternion.Euler(0, rndRotY, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
