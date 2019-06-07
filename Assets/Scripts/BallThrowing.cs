using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrowing : MonoBehaviour
{
    private Camera cam;
    private GameObject newBall;
    private bool holdingBall = false;

    [SerializeField] private GameObject ball;
    [SerializeField] private float throwForce = 1000f;
    [SerializeField] private Vector3 holdOffset = new Vector3(0, 0, 1);

    void Awake()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Start()
    {
        StartCoroutine(BallRespawn());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && holdingBall)
        {
            ThrowBall();
        }
    }

    void SpawnBall()
    {
        newBall = Instantiate(ball);
        // Parent Ball
        newBall.transform.parent = cam.transform;
        newBall.transform.localPosition = holdOffset;
        // Disable Rigidbody and Collider
        newBall.GetComponent<SphereCollider>().enabled = false;
        newBall.GetComponent<Rigidbody>().useGravity = false;
        newBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        newBall.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        
        holdingBall = true;

    }

    void ThrowBall()
    {
        // Unparent Ball
        newBall.transform.parent = null;
        //Enable collider and physics and add a force.
        newBall.GetComponent<SphereCollider>().enabled = true;
        newBall.GetComponent<Rigidbody>().useGravity = true;
        newBall.GetComponent<Rigidbody>().AddForce(cam.transform.forward * throwForce);
        
        holdingBall = false;
        StartCoroutine(BallRespawn());
    }

    IEnumerator BallRespawn()
    {
        yield return new WaitForSeconds(2f);
        SpawnBall();
    }
}
