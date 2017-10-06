using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Bird hit the: " + col.name);
    }

    private void Start()
    {
        Debug.Log("Heelooo!!");
    }

}
