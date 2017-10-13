using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text orbCountText;
    public Text tutorialText;
    public float playerSpeed = 0.1f;
    float jumpForce = 5;
    public Transform playerTransform;
    public Transform handTransform;
    Rigidbody rb;
    public GameObject[] lightOrbs;
    public GameObject lightOrb;
    float orbCount = 0;
    public float time1 = 1f;
    public float time2 = 0.0f;
    public bool frozen = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LightOrb")
        {
            orbCount += 1;
            Destroy(other.gameObject);
            orbCountText.text = orbCount.ToString("##");
        }       
    }
    
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        MovePlayer();
        Tutorial();
        FireOrb();
    }

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerTransform.position -= new Vector3(playerSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerTransform.position += new Vector3(playerSpeed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && playerTransform.transform.position.y <= 7)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    void Tutorial()
    {
        if (time1 >= 1 && time1 <= 3.0f)
        {
            time1 += Time.deltaTime;
            tutorialText.text = "USE W AND S TO MOVE AND SPACE TO JUMP";
        }
        if (time1 > 3.0f)
        { 
            tutorialText.text = "WALK TO THE YELLOW ORB";
        }
        if(orbCount == 1)
        {
            tutorialText.text = "YOU HAVE COLLECTED AN ORB!";
            time1 = 0;
            time2 += Time.deltaTime;
        }        
        if(time2 > 3 && orbCount==1)
        {
            tutorialText.text = "COLLECT 2 MORE ORBS!";
        }
        if(orbCount == 3)
        {
            tutorialText.text = "GREAT! LEFT CLICK TO FIRE ORB";
        }
        return;
    }
    
    
    void FireOrb()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && orbCount>= 1)
        {
            GameObject orb = GameObject.FindGameObjectWithTag("LightOrbFire");
            Instantiate(lightOrb, handTransform.transform.position, Quaternion.identity);
            orbCount -= 1;
            orbCountText.text = orbCount.ToString("##");
            if(orbCount == 0)
            {
                orbCountText.text = "0";
            }
        }
    }
    
}
