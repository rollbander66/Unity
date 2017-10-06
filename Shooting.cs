using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public GameObject projectile;
    public AudioClip shootSound;

    private float throwSpeed = 2000f;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    GameObject go;
    Ray ray;
    RaycastHit hit;

    public float gunDmg = 100f;

    void Awake () 
	{
        source = GetComponent<AudioSource>();
    }	
	
    // Update is called once per frame
    void Update () 
	{

        if (Input.GetButtonDown("Fire1"))            
        {
			float vol = Random.Range (volLowRange, volHighRange);
            source.PlayOneShot(shootSound,vol);
            
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);                        
            if (Physics.Raycast(ray, out hit, 1000))
            {
                go = hit.transform.gameObject;
                HealthController h = go.GetComponent<HealthController>();

                if (h != null ) {
                    h.takeDamage(gunDmg);
                }               
            }
            
			GameObject throwThis = Instantiate (projectile, transform.position, transform.rotation) as GameObject;
            throwThis.rigidbody.AddRelativeForce (new Vector3(0,0,throwSpeed));			
        }
	}
}
