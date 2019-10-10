using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shota_rotate : MonoBehaviour {

    [SerializeField] float n;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, n);
	}
}
