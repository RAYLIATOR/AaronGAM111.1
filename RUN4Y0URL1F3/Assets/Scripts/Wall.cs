using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float wallHealth=300;
    public Transform wallTransform;
    public GameObject debris;
    public Transform debrisTransform;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        DestroyWall();
	}
    void DestroyWall()
    {
        if(wallHealth==0)
        {
            Destroy(this.gameObject);
            //Instantiate(debris, debrisTransform.transform.position, Quaternion.identity);
        }
    }
}
