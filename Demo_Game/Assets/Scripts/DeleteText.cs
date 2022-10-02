using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteText : MonoBehaviour
{
    public GameObject Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the Enemy tag
        if (collision.gameObject.tag == "Player")
        {
            //tells code that you died
            Destroy(Text);


        }
    }
}
