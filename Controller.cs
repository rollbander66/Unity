using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public float fwdSpd;
    public float mouseSpeed;
    public float jumpSpeed;

    CharacterController cc;
    Vector3 speed;
    float fwd;
    float bck;
    float mouseY = 0.0f;
    float Look = 60.0f;    
    float vertVel = 0.0f;

    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
     
        // Mouse Movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed;
        transform.Rotate(0.0f, mouseX, 0.0f);

        mouseY -= Input.GetAxis("Mouse Y") * mouseSpeed;
        mouseY = Mathf.Clamp(mouseY, -Look, Look);
        Camera.main.transform.localRotation = Quaternion.Euler(mouseY, 0.0f, 0.0f);
        
        // Jump
        if (cc.isGrounded)
        {
            vertVel = 0;
        }
        vertVel += Physics.gravity.y * Time.deltaTime;
        if (cc.isGrounded && Input.GetButtonDown("Jump"))
        {
            vertVel = jumpSpeed;
        }
               
        // Keyboard Movement
        fwd = Input.GetAxis("Horizontal") * fwdSpd;
        bck = Input.GetAxis("Vertical") * fwdSpd;

        speed = new Vector3(fwd, vertVel, bck);
        speed = transform.rotation * speed;
        cc.Move(speed * Time.deltaTime);
    }
}
