using UnityEngine;
using System.Collections;

public class Hider : Player {
    public int dashDelay = 3;
    private float lastDashTime = 0f;
    private bool canDash = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        base.Movement();
        Dash();
        if(this.health <= 0)
        {
            base.Destroy();
        }
	}

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            transform.Translate(new Vector2(.2f, 0));
            lastDashTime = Time.time;
            canDash = false;
        }
        if ((Time.time - lastDashTime > dashDelay) && !canDash)
        {
            canDash = true;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Spike")
        {
            base.Damage(2);
            transform.Translate(new Vector2(-.1f, 0));
            Debug.Log("damaged");
        }
    }
}
