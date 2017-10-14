using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossOrb : MonoBehaviour
{
    //variables
    public float bossOrbTime;
    public Transform bossOrb;
    public float bossOrbSpeed = 0.3f;

    //checks for collision with player
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player p = collision.gameObject.GetComponent<Player>();
            p.playerHealth -= 200;
            Destroy(this.gameObject);
        }
    }
        void Start ()
    {		
	}
	
	void Update ()
    {
        SimulateBossOrb();
    }
    //Moves enemy orb
    public void SimulateBossOrb()
    {
        bossOrbTime += Time.deltaTime;
        if (bossOrbTime >= 2f)
        {
            bossOrb.transform.position += new Vector3(bossOrbSpeed, 0, 0);
        }
    }
}
