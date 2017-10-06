using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {

    // To be tweaked via the Inspector
	public float RunMovementSpeed = 8.0f;
    public float SprintMovementSpeed = 16.0f;
    public float mouseSpeed = 3.0f;    
    public float jumpSpeed = 8.0f;

    float verticalRot = 0;
    float vertVel = 0;
    float upDownRange = 65.0f;
    //float jetpackHeightLimit = 25.0f;
    float speed;

    CharacterController cc;
    Vector3 spd;

    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {

        // Mouse Rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed;
        transform.Rotate(0, mouseX, 0);

        verticalRot -= Input.GetAxis("Mouse Y") * mouseSpeed;
        // Setup a limit to which we can look up and down.
        verticalRot = Mathf.Clamp(verticalRot, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRot, 0, 0);

        // Player Movement
        if (cc.isGrounded)
        {
            vertVel = 0;
        }
        // Let the player Jump if grounded
        if (Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            vertVel = jumpSpeed;
        }

        // Sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Sprinting");
            speed = SprintMovementSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("Running");
            speed = RunMovementSpeed;
        }

        float frwd = Input.GetAxis("Vertical") * speed;
        float side = Input.GetAxis("Horizontal") * speed;

        spd = new Vector3(side, vertVel, frwd);
        spd = transform.rotation * spd;
        cc.Move(spd * Time.deltaTime);
    }

    bool isJetPackToggled()
    {
        if (Input.GetKeyDown(KeyCode.J)) {
            return true;
        }
        if (Input.GetKeyUp(KeyCode.J)) {
            return false;
        }
        return false;
    }

}
