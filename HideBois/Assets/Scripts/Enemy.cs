using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public Transform target;
    private Vector3 target_pos;
    private float angle;
	// Update is called once per frame
	void Update () {
        target_pos = target.position;
        target_pos.x = target_pos.x - transform.position.x;
        target_pos.y = target_pos.y - transform.position.y;
        angle = Mathf.Atan2(target_pos.y, target_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.Translate(new Vector2(.15f*Time.deltaTime, 0));
    }
}
