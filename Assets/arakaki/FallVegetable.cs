using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallVegetable : MonoBehaviour
{
    [SerializeField]
    public float fallSpeed = -0.03f;

    
	// Use this for initialization
    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "player")
    //    {

    //        Destroy(gameObject, 0.2f);
    //    }
    //}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, this.fallSpeed, 0);
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
	}
}
