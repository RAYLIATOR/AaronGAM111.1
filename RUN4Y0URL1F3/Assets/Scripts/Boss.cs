using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform bossTransform;
    public float bossHealth = 1000;
    public GameObject bossOrb;
    public float fireTime = 0.0f;
    public bool bossFight = false;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        DestroyBoss();
        BossFire();
    }
    void DestroyBoss()
    {
        if (bossHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }
    void BossFire()
    {
        
        if (bossFight == true)
        {
            fireTime += Time.deltaTime;
            if (fireTime >= 5)
            {
                Instantiate(bossOrb, this.transform.position, Quaternion.identity);
                fireTime = 0.0f;
            }
        }
    }
}
