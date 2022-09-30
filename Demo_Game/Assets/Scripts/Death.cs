using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the Enemy tag
        if (collision.gameObject.tag == "Enemy")
        {
            //tells code that you died
                Debug.Log("You Died");

        //Restart level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
