using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Orb : MonoBehaviour
{
    //Variables
    public Transform lightOrb;
    public Transform wall;
    public float orbSpeed = 0.2f;
    public float orbTime = 0;
    float wallOrbDistance;

    //Checks for collisions with wall and enemy
    void OnTriggerEnter(Collider collision)
    {       
        if (collision.gameObject.tag == "Wall")
        { 
            Wall w = collision.gameObject.GetComponent<Wall>();
            w.wallHealth -= 100;
            Destroy(this.gameObject);
        }
        
        if (collision.gameObject.tag == "Boss")
        {
            Boss b = collision.gameObject.GetComponent<Boss>();
            b.bossHealth -= 100;
            Destroy(this.gameObject);
        }
    }
    
    void Start ()
    {		
	}
	
	void Update ()
    {
        SimulateOrb();
    }

    //orb movement
    public void SimulateOrb()
    {
        orbTime += Time.deltaTime;
        if (orbTime >= 2f)
        {
            lightOrb.transform.position -= new Vector3(orbSpeed, 0, 0);
        }
    }    
}
