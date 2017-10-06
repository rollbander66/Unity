using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

    public float hitPoints;

	public void takeDamage(float dmgAmt)
    {
        hitPoints -= dmgAmt;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
