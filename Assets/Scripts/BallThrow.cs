using UnityEngine;

public class BallThrow : MonoBehaviour
{
    Camera cam;
    private bool holdingBall = false;

    private Ball ball;
    public Vector3 offset = new Vector3(0, 0, 1);    
    public float throwForce = 1000f;
    public float grabDistance = 4f;

    void Awake()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!holdingBall)
            {
                RaycastHit hit;
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, grabDistance) == true) //Check for the object the player is looking at.
                {
                    Ball tempBall = hit.collider.GetComponent<Ball>();
                    if (tempBall != null) //If the object is a ball (has a Ball script), then grab it.
                    {
                        ball = tempBall;
                        GrabBall();
                    }
                }
            }
            else if (holdingBall)
            {
                ThrowBall();
            }
        }
    }

    void GrabBall()
    {
        holdingBall = true;
        //Disable collider and physics and reset physics.
        ball.GetComponent<SphereCollider>().enabled = false;
        ball.GetComponent<Rigidbody>().useGravity = false;
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        ball.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        //Set parent to camera and offset the balls position.
        ball.transform.parent = cam.transform;
        ball.transform.localPosition = offset;
    }

    void ThrowBall()
    {
        holdingBall = false;
        //Enable collider and physics and add a force.
        ball.GetComponent<SphereCollider>().enabled = true;
        ball.GetComponent<Rigidbody>().useGravity = true;
        ball.GetComponent<Rigidbody>().AddForce(cam.transform.forward * throwForce);
        //Unparent the ball.
        ball.transform.parent = null;
    }
}
