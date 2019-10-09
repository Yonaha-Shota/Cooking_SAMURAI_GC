using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MoveChara : MonoBehaviour {

    GameObject chara;
    public const float Y = -3.75f;
    public float speed = -2.5f;

    public float X = -7.0f;

    public bool Wait,Right,Left;

public Vector2 vec;


    // Use this for initialization
    void Start () {
        Wait  = true;
        Right = false;
        Left  = false;

        chara = GameObject.FindWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
        if ((X > -8) && (X < 4)) { 
            if(Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.RightArrow))
             X += (Input.GetAxisRaw("Horizontal") * speed);
        }

        if (X <= -7.0f)
        {
            X = -7.0f;
        }
        if (X >= 3.0f)
        {
            X = 3.0f;
        }

        Vector2 direction = new Vector2(X, 0).normalized;

        // 移動する向きとスピードを代入する
        GetComponent<Rigidbody2D>().position = new Vector2(X,0);


        //没
        /* X = Input.GetAxisRaw("Horizontal");

       if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.LeftArrow))
       {

           Wait = true;
           Right = false;
           Left = false;

       }

       Vector2 direction = new Vector2(X, 0).normalized;

       // 移動する向きとスピードを代入する
       GetComponent<Rigidbody2D>().velocity = direction * speed;

       if (Input.GetKey(KeyCode.LeftArrow))
//        if()
       {
           Wait  = false;
           Right = false;
           Left  = true;

           //vec.x -= speed;
       }

       if (Input.GetKey(KeyCode.LeftArrow))
 //        if()
       {
           Wait  = false;
           Right = true;
           Left  = false;

           //vec.x += speed;
       }*/
    }
}
