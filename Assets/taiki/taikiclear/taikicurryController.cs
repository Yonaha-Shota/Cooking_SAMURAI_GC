using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class taikicurryController : MonoBehaviour {

    private float curryspeed=-3.0f;
    private float curryposition = 0f;
    float posx,posy;
    [SerializeField]
    private GameObject ParticleObject;
    ParticleSystem cash;
    bool particleflg;
	// Use this for initialization
	void Start () {
        posx = GetComponent<RectTransform>().position.x;
        posy = GetComponent<RectTransform>().position.y;
        cash = ParticleObject.GetComponent<ParticleSystem>();
        cash.Stop();
       
    }
	
	// Update is called once per frame
	void Update () {
        posy += curryspeed;
        GetComponent<RectTransform>().position = new Vector3(posx, posy, 0);
        Debug.Log(posy);

        if (posy <= 900)
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
