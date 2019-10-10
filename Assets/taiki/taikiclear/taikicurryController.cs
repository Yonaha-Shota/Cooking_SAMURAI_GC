using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class taikicurryController : MonoBehaviour {

    private float curryspeed=-0.3f;
    private float curryposition = 0f;
    float posx,posy;
    [SerializeField]
    private GameObject ParticleObject;
    ParticleSystem cash;
    bool particleflg;
	// Use this for initialization
	void Start () {
        posx = GetComponent<Transform>().position.x;
        posy = GetComponent<Transform>().position.y;
        cash = ParticleObject.GetComponent<ParticleSystem>();
        cash.Stop();
       
    }
	
	// Update is called once per frame
	void Update () {
        posy += curryspeed;
        GetComponent<Transform>().position = new Vector3(posx, posy, 0);
        Debug.Log(posy);

        if (posy <= 3)
        {
            Debug.Log("止まる");
            curryspeed = 0;
            particleflg = true;
        }
        if (particleflg)
        {
            cash.Play();
        }
    }
}
