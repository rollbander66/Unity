using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Looper : MonoBehaviour {

    int numPanels = 10;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("BG Looper hit the: " + collision.name);

        float widthOfBG = ((BoxCollider2D)collision).size.x;

        Vector3 pos = collision.transform.position;
        pos.x += widthOfBG * numPanels / 1.5f;
        collision.transform.position = pos;
    }
}
