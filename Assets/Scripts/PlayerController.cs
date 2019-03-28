using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float camSensitivity;

    private Vector3 velocity;
    private float camAngleX;
    private float camAngleY;
    private float gravity;
    public float gravityConstant;
    public Vector3 jumpVelocity = new Vector3(0, 1, 0);

    private bool grounded = false;
    private bool wasGrounded = false;

    public CharacterController characterController;
    private new GameObject camera;
    protected Collider coll;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        camera = GetComponentInChildren<Camera>().gameObject;
        coll = GetComponent<Collider>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Get the keyboard/joystick input on two axes from -1 to 1 (digital)
        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        grounded = characterController.isGrounded;

        //Check landings
        if (grounded != wasGrounded && grounded == true) //The player just landed
        {
            Landed();
        }

        if (vert != 0 || hor != 0)
        {
            //Multiply the z (forward/backward) and x (right/left) axis of the player by the input and the speed
            Vector3 velXZ = (vert * transform.forward + hor * transform.right) * speed;
            velocity = new Vector3(velXZ.x, velocity.y, velXZ.z);
        }
        else
        {
            //When there is no input, stop the player
            velocity = new Vector3(0, velocity.y, 0);
        }

        //Gravity
        if (!grounded)
        {
            gravity = gravityConstant * Time.deltaTime;
            velocity -= new Vector3(0, 1, 0) * gravity;
        }
        else
        {
            velocity -= new Vector3(0, 0, 0);
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GroundedTest()) //Check if the player is on the ground
            {
                velocity = new Vector3(velocity.x, jumpVelocity.y, velocity.z);
                gravity = 0;
            }
        }

        //Rotation and camera
        float camX = Input.GetAxis("Mouse X");
        float camY = Input.GetAxis("Mouse Y");

        camAngleX += camX * camSensitivity;
        camAngleY += camY * camSensitivity;
        camAngleY = Mathf.Clamp(camAngleY, -90, 90);
            //The camera is rotated up and down axis without the player object rotating
        camera.transform.localRotation = Quaternion.Euler(-camAngleY, 0, 0);
            //The player object is rotated left and right. The camera does the same because it is a child of the player object
        transform.rotation = Quaternion.Euler(0, camAngleX, 0);

        //Update wasGrounded so we can check during the next update if the player has landed.
        wasGrounded = grounded;
    }

    private void Landed()
    {
        //Multiply the x and z velocity by 1 so they don't change, and the y velocity by 0 so it becomes 0.
        velocity = Vector3.Scale(velocity, new Vector3(1, 0, 1));
    }

    private bool GroundedTest() //Casts 9 rays under the player and checks for collisions.
    {
        bool checkGrounded = false;
        Vector3 offset;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                offset = new Vector3(i * characterController.radius, 0, j * characterController.radius); //Creates a 3x3 grid from which the rays will be cast.

                if (Physics.Raycast(transform.position + offset, Vector3.down, coll.bounds.extents.y + 0.1f) == true) //Look directly below the player and return true if there is a collider there.
                {
                    checkGrounded = true;
                }
            }
        }
        return checkGrounded;
    }

    private void FixedUpdate()
    {
        //Make the player move
        characterController.Move(velocity * Time.deltaTime);
    }
}
