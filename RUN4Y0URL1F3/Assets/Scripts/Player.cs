using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Variables
    public Text orbCountText;
    public Text tutorialText;
    public Text healthText;
    public GameObject pauseMenuPanel;
    public GameObject HUDPanel;
    float playerSpeed = 7f;
    float jumpForce = 5;
    public Transform playerTransform;
    public Transform handTransform;
    Rigidbody rb;
    public GameObject[] lightOrbs;
    public GameObject lightOrb;
    float orbCount = 0;
    float time1 = 1f;
    float time2 = 0.0f;
    bool tutorial = true;
    public GameObject checkpoint1;
    public float playerHealth = 1000;

    //Check for collision with yellow orbs, checkpoints
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LightOrb")
        {
            orbCount += 1;
            Destroy(other.gameObject);
            orbCountText.text = orbCount.ToString("##");
        }
        if (other.tag == "Checkpoint1")
        {
            tutorial = false;
        }
        if (other.tag == "Checkpoint2")
        {
            SceneManager.LoadScene(3);
        }
    }

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	void Update ()
    {
        MovePlayer();
        Tutorial();
        FireOrb();
        PlayerDie();
        healthText.text = playerHealth.ToString("##");
        Pause();
    }

    //Player Movement
    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerTransform.position -= new Vector3(playerSpeed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerTransform.position += new Vector3(playerSpeed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && playerTransform.transform.position.y <=10)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 14f;
        }
        else
        {
            playerSpeed = 7f;
        }
    }
    
    //Text-based tutorial
    void Tutorial()
    {
        if (time1 >= 1 && time1 <= 3.0f)
        {
            time1 += Time.deltaTime;
            tutorialText.text = "USE W AND S TO MOVE AND SPACE TO JUMP";
        }
        if (time1 > 3.0f && tutorial == true)
        { 
            tutorialText.text = "WALK TO THE YELLOW ORB";
        }
        if (orbCount == 1 && tutorial == true)
        {
            tutorialText.text = "YOU HAVE COLLECTED AN ORB!";
            time1 = 0;
            time2 += Time.deltaTime;
        }        
        if(time2 > 3 && orbCount==1 && tutorial == true)
        {
            tutorialText.text = "COLLECT 2 MORE ORBS!";
        }
        if(orbCount == 3 )
        {
            tutorialText.text = "GREAT! LEFT CLICK TO FIRE ORB";
        }
        if(orbCount>=4)
        {
            tutorialText.text = "DEFEAT THE BOSS";
        }
    }    
    
    //Fires orb
    void FireOrb()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && orbCount>= 1)
        {
            //GameObject orb = GameObject.FindGameObjectWithTag("LightOrbFire");
            Instantiate(lightOrb, handTransform.transform.position, Quaternion.identity);
            orbCount -= 1;
            orbCountText.text = orbCount.ToString("##");
            if(orbCount == 0)
            {
                orbCountText.text = "0";
            }
        }
    }

    //Player dies if health reaches 0
    void PlayerDie()
    {
        if(playerHealth<=0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(2);
        }
    }
    void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenuPanel.gameObject.SetActive(true);
            HUDPanel.gameObject.SetActive(false);
        }
    } 
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenuPanel.gameObject.SetActive(false);
        HUDPanel.gameObject.SetActive(true);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }   
}
