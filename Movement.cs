using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Vector3 vel = Vector3.zero;
    public Vector3 gravity;
    bool didFlap = false;
    public Vector3 flapVelocity;
    public float maxSpeed;
    public float forwardSpeed;

    // Use this for initialization
    void Start () {
        
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            didFlap = true;    
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        vel.x = forwardSpeed;
        vel += gravity * Time.deltaTime;

        if (didFlap)
        {
            didFlap = false;
            if (vel.y < 0)
            {
                vel.y = 0;
            }
            vel += flapVelocity;
        }

        vel = Vector3.ClampMagnitude(vel, maxSpeed);
        transform.position += vel * Time.deltaTime;

        float angle = 0;
        if (vel.y < 0)
        {
            angle = Mathf.Lerp(0, -90, -vel.y / maxSpeed);
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
}
