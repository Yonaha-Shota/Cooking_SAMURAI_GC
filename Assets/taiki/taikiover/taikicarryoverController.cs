using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taikicarryoverController : MonoBehaviour {

    private float curryspeed = -3.0f;
    private float curryposition = 0f;
    float posx, posy;
    bool particleflg;
    // Use this for initialization
    void Start()
    {
        posx = GetComponent<RectTransform>().position.x;
        posy = GetComponent<RectTransform>().position.y;


    }

    // Update is called once per frame
    void Update()
    {
        posy += curryspeed;
        GetComponent<RectTransform>().position = new Vector3(posx, posy, 0);
        Debug.Log(posy);

        if (posy <= 500)
        {
            Debug.Log("止まる");
            curryspeed = 0;

        }
    }
}
