using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour {
    public Vector2 speed;
    public Vector2 direction;

    // Initialize some variables
    private void Start()
    {
        speed = new Vector2(1, 1);
        direction = new Vector2(0, 1);
    }
    // Update is called once per frame
    void Update () {
        // Calculate the change in movement depending on speed and direction.
        Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);
        // Smoother frame dependent movement in case of lag or whatnot
        movement *= Time.deltaTime;
        transform.Translate(movement);
	}
}
