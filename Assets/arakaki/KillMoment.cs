using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMoment : MonoBehaviour
{

    // Use this for initialization

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("----斬----");
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           
            Destroy(other.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {

             //Destroy(gameObject);
        
    }
}