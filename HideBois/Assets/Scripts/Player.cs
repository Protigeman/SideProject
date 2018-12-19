using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float moveSpd = 1.0f;
    private Rigidbody rb;
    private float disToGround = 0.5f;
    public int health = 10;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Movement();
        Direction();

        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Vector3 jumpVelocity = new Vector3(0f, 0f, moveSpd);
            rb.velocity += jumpVelocity;
        }
    }
    public void Direction()
    {
        if(Input.mousePosition.x > 0)
        {
            transform.Rotate(Vector3.up);
        }
        
    }
    public void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector2(moveSpd * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector2(-1 * moveSpd * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(0, moveSpd * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(0,-1*moveSpd * Time.deltaTime));
        }
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, disToGround);
    }

    public void Damage(int dmg)
    {
        this.health -= dmg;
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
