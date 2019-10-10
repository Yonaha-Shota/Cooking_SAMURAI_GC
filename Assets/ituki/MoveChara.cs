using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChara : MonoBehaviour {

   //定数
    private const float LEFT = -7.0f;
    private const float RIGHT = 3.0f;

    //変数
    public const float Y = -3.75f;
    public float speed = -2.5f;

    public float X = -7.0f;

    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
        if ((X > LEFT - 1) && (X < RIGHT + 1)) { 
            if(Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.RightArrow))//左右キーいずれかを押したときのみ
             X += (Input.GetAxisRaw("Horizontal") * speed);//左右を判断しXを±1する
        }

        if (X <= LEFT){X = LEFT;}//範囲指定
        if (X >= RIGHT){X = RIGHT;}//範囲指定

        //不要　Vector2 direction = new Vector2(X, 0).normalized;

        // 位置移動
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
