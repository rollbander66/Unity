using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    Transform trans;
    float offsetX;
	
    // Use this for initialization
	void Start () {
        GameObject player_go = GameObject.FindGameObjectWithTag("Player");

        trans = player_go.transform;
        offsetX = transform.position.x - trans.position.x;

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x = trans.position.x + offsetX;
        transform.position = pos;
	}
}
