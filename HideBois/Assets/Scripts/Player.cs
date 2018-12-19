using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private float moveSpd = 1.0f;
    private Rigidbody rb;
    private float disToGround = 0.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Movement();

        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Vector3 jumpVelocity = new Vector3(0f, moveSpd, 0f);
            rb.velocity += jumpVelocity;
        }
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 position = this.transform.position;
            position.x += moveSpd;
            this.transform.position = position;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 position = this.transform.position;
            position.x -= moveSpd;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 position = this.transform.position;
            position.z += moveSpd;
            this.transform.position = position;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector3 position = this.transform.position;
            position.z -= moveSpd;
            this.transform.position = position;
        }
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, disToGround);
    }
}
