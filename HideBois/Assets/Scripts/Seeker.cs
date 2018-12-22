using UnityEngine;
using System.Collections;

public class Seeker : Player {
    public int sprintDelay = 10;
    private float lastSprintTime = 0f;
    private bool canSprint = true;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        /*base.Movement();
        Sprint();*/
        transform.LookAt(GameObject.FindWithTag("Hider").transform);
        transform.Translate(new Vector2(.01f, 0));

	}

    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canSprint)
        {
            moveSpd += .2f;
            lastSprintTime = Time.time;
            canSprint = false;
        }
        if ((Time.time - lastSprintTime > sprintDelay) && !canSprint)
        {
            canSprint = true;
        }
    }
}
