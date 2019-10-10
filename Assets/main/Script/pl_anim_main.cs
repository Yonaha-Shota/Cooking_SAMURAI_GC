using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pl_anim_main : MonoBehaviour {

    [SerializeField] Animation target_anim;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            target_anim.Play();
        }
    }
}
