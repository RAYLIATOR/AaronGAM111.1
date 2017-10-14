using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    //variables
    public Transform bossTransform;
    public float bossHealth = 1000;
    public GameObject bossOrb;
    float fireTime = 0.0f;
    public float playerDistance;
    public Transform playerTransform;
    
    void Start ()
    {		
	}
	
	void Update ()
    {
        DestroyBoss();
        BossFire();
    }
    //destroys enemy if health reaches 0
    void DestroyBoss()
    {
        if (bossHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }
    //enemy fires orbs
    void BossFire()
    {
        playerDistance = Vector3.Distance(playerTransform.transform.position, bossTransform.transform.position);
        if (playerDistance<=70f)
        {
            fireTime += Time.deltaTime;
            if (fireTime >= 3)
            {
                Instantiate(bossOrb, this.transform.position, Quaternion.identity);
                fireTime = 0.0f;
            }
        }
    }
}
