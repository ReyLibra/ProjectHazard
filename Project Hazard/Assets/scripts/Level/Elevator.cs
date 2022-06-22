using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public bool detonator = false;
    public bool explosive = false;
    public Scene currScene;
    public string sceneName;

    private stage1 stage1;
    private stage2 stage2;

    public AudioClip moveSound;
    public AudioSource audio;

    void Start()
    {
        stage1 = FindObjectOfType<stage1>();
        stage2 = FindObjectOfType<stage2>();
        currScene = SceneManager.GetActiveScene();
        sceneName = currScene.name;
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        /*if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("quit!");
            Application.Quit();
        }*/
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (sceneName == "Stage_1")
        {
            if (collision.transform.tag == "Player" && detonator == true && explosive == true)
            {
                audio.PlayOneShot(moveSound, 1.0f);
                GameObject.FindWithTag("Player").GetComponent<CharacterController>().enabled = false;
                GameObject.FindWithTag("Player").GetComponent<Rigidbody>().isKinematic = true;
                GameObject.FindWithTag("Player").GetComponent<Rigidbody>().velocity = Vector3.zero;
                GameObject.FindWithTag("Player").GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                stage1.LoadNextLevel();
            }
        } else {
            if (collision.transform.tag == "Player" && stage2.canExit == true && sceneName == "Stage_2")
            {
                audio.PlayOneShot(moveSound, 1.0f);
                stage2.LoadNextLevel();
            }
        }
    }
}
