using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOrb : MonoBehaviour
{
    public float bossOrbTime;
    public Transform bossOrb;
    public float bossOrbSpeed = 0.3f;
    // Use this for initialization
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Player p = collision.gameObject.GetComponent<Player>();
            p.playerHealth -= 200;
            Destroy(this.gameObject);
        }
    }
        void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        SimulateBossOrb();
    }
    public void SimulateBossOrb()
    {
        bossOrbTime += Time.deltaTime;

        if (bossOrbTime >= 2f)
        {
            bossOrb.transform.position += new Vector3(bossOrbSpeed, 0, 0);
        }
    }
}
