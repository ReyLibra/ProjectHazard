using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class stage2 : MonoBehaviour
{
    public GameObject levelColliders;
    public GameObject levelInteract;
    public GameObject levelDress;
    public GameObject levelCharger;
    public GameObject levelElevator;
    public GameObject balleeTrident;
    public GameObject balleeSword;
    public GameObject cam;
    public NavMeshSurface surface;
    public GameObject hudUI;
    public GameObject gameOverUI;
    public GameObject pauseUI;

    public Animator transition;

    public bool canExit;
    public int chargedPads = 0;
    public bool playercharging = false;
    
    private int count;
    //public int characterToggle = 0;

    void Awake()
    {
        GameObject.Instantiate (levelColliders, transform.position, transform.rotation * Quaternion.Euler (0f, 45f, 0f));
        surface.BuildNavMesh();
        GameObject.Instantiate (levelInteract, new Vector3(0.0f, 3.0f, 0.0f), transform.rotation * Quaternion.Euler (0f, 0f, 0f));
        GameObject.Instantiate (levelDress, transform.position, transform.rotation * Quaternion.Euler (0f, 45f, 0f));
        GameObject.Instantiate (levelCharger, new Vector3(-14f, 5.4f, -39f), transform.rotation * Quaternion.Euler (0f, 45f, 0f));
        GameObject.Instantiate (levelCharger, new Vector3(-9.5f, 5.4f, 29f), transform.rotation * Quaternion.Euler (0f, 135f, 0f));
        GameObject.Instantiate (levelCharger, new Vector3(0f, 30.4f, 56f), transform.rotation * Quaternion.Euler (0f, 180f, 0f));
        GameObject.Instantiate (levelElevator, new Vector3(0f, 18.34f, -57.75f), transform.rotation * Quaternion.Euler (0f, 45f, 0f));
        
        
        /*
        if (characterToggle == 0)
            GameObject.Instantiate (balleeTrident, new Vector3(-58f, 40f, 8f), transform.rotation * Quaternion.Euler (0f, 45f, 0f)); 
        else if (characterToggle == 1)
            GameObject.Instantiate (balleeSword, new Vector3(-58f, 40f, 8f), transform.rotation * Quaternion.Euler (0f, 45f, 0f)); 
        */
        GameObject.Instantiate (cam, transform.position, transform.rotation);
        GameObject.Instantiate (hudUI, transform.position, transform.rotation);
        GameObject.Instantiate (gameOverUI, transform.position, transform.rotation);
        GameObject.Instantiate (pauseUI, transform.position, transform.rotation);

        canExit = false;
    }
    void Start()
    {
        /*GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
        GameObject.FindWithTag("Player").GetComponent<Rigidbody>().velocity = Vector3.zero;
        GameObject.FindWithTag("Player").GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        */
        //GameObject.FindWithTag("Player").transform.position =  new Vector3(-58f, 45f, 8f);
        GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = false;
        GameObject.FindWithTag("Player").transform.position =  new Vector3(-55f,19f,4f);
        GameObject.FindWithTag("Player").GetComponent<CharacterController>().enabled = true;
        
        //GameObject.FindWithTag("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
    }
    void Update()
    {
        /*
        if(GameObject.FindWithTag("Player").transform.position.y <=)
        {
            GameObject.FindWithTag("Player").transform.position =  new Vector3(-58f, 45f, 8f);
        }
        */
    }
    public void LoadNextLevel()
    {
        Destroy(GameObject.FindWithTag("Player"));
        Destroy(GameObject.Find("LoadoutPrefab"));
        StartCoroutine(LoadLevel(4));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
    }
}
