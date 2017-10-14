using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    //Variables
    public float wallHealth=300;
    public Transform wallTransform;
    
    void Start ()
    {		
	}
	
	void Update ()
    {
        DestroyWall();
	}

    //Destroys wall after 3 orb shots
    void DestroyWall()
    {
        if(wallHealth==0)
        {
            Destroy(this.gameObject);            
        }
    }
}
