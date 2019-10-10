using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;     //UIを使用可能にする

public class Object_Zan_main : MonoBehaviour
{

    [SerializeField] private int vegiID; // 0じゃが1にんじん2たま


    Animator animator;

    SpriteRenderer spriteRenderer;

    FallVegetable FallVegetable;

    bool fadeoutflg;

    GameObject zan_Child;
    SpriteRenderer zan_renderer;
    Animator zan_animator;
    bool zan_fadeoutflg;

    /********にんじん*************/
    GameObject carrot_object;
    Animator carrot_animator;
    SpriteRenderer carrotrenderer;

    FallVegetable carrot_fallvegetable;

    bool carrot_fadeoutflg;
    /*****************************/


    /********ポテト**************/
    GameObject potato_object;
    Animator potato_animator;
    SpriteRenderer potatorenderer;

    FallVegetable potato_fallvegetable;

    bool potato_fadeoutflg;
    /****************************/


    /********オニオン************/
    GameObject onion_object;
    Animator onion_animator;
    SpriteRenderer onionrenderer;

    FallVegetable onion_fallvegetable;

    bool onion_fadeoutflg;
    /****************************/


    GameObject zanCarrot_Child;
    SpriteRenderer zanCarrot_renderer;
    Animator zanCarrot_animator;
    bool zanCarrot_fadeoutflg;


    GameObject zanPotato_Child;
    SpriteRenderer zanPotato_renderer;
    Animator zanPotato_animator;
    bool zanPotato_fadeoutflg;


    GameObject zanOnion_Child;
    SpriteRenderer zanOnion_renderer;
    Animator zanOnion_animator;
    bool zanOnion_fadeoutflg;


    /*************共通**************/
    float red = 1, green = 1, blue = 1;    //RGBを操作するための変数
    float speed = -0.01f;  //透明化の速さ
    float alfa = 1;    //A値を操作するための変数
    float span = 0.80f; //フェイドアウト開始時間
    float delta = 0;

    float cutfall_speed = -0.01f;
    /********************************/

    float zanspeed = -0.0001f;
    // float zanPotaospeed = -0.0001f; 
    // Use this for initialization

    void OnTriggerStay2D(Collider2D other)
    {

        // Debug.Log("----斬----");
        if (Input.GetKeyDown(KeyCode.UpArrow))/************↑キーを押したとき******/
        {

            /***********にんじん******************/
            if (other.gameObject.tag == "Player" && vegiID == 1)
            {
                zanCarrot_renderer.enabled = true;
                carrot_animator.SetBool("Carrot_Cutflg", true);
                carrot_fadeoutflg = true;

                zanCarrot_animator.SetBool("Zan_Cutflg", true);
                zanCarrot_fadeoutflg = true;

                Debug.Log("aaaaaaaaaa");
            }
            /*************************************/

            /***********ポテト*******************/
            if (other.gameObject.tag == "Player" && vegiID == 0)
            {
                zanPotato_renderer.enabled = true;
                potato_animator.SetBool("Potato_Cutflg", true);
                potato_fadeoutflg = true;

                zanPotato_animator.SetBool("Zan_Cutflg", true);
                zanPotato_fadeoutflg = true;

            }
            /************************************/

            /***********オニオン****************/
            if (other.gameObject.tag == "Player" && vegiID == 2)
            {
                onion_animator.SetBool("Onion_Cutflg", true);
                onion_fadeoutflg = true;
                zanOnion_renderer.enabled = true;
                zanOnion_animator.SetBool("Zan_Cutflg", true);
                zanOnion_fadeoutflg = true;

            }

            /**********************************/

        }/***************************************************************/

        /*********フェイドアウトが終了したときに削除*********/
        if (alfa < 0)
        {




            /***********にんじん************************/
            if (vegiID == 1)
            {


                Destroy(gameObject);
                carrot_fadeoutflg = false;
            }
            /*************************************/

            /***********ポテト*******************/
            if (vegiID == 0)
            {
                Destroy(gameObject);
                potato_fadeoutflg = false;
            }
            /************************************/

            /***********オニオン****************/
            if (vegiID == 2)
            {

                Destroy(gameObject);
                onion_fadeoutflg = false;
            }
            /**********************************/

        }/********************************************/



    }

    void Start()
    {



        /************にんじん***************/
        if (vegiID == 1) {
            carrot_object = gameObject;
            this.carrot_animator = carrot_object.GetComponent<Animator>();
            this.carrotrenderer = carrot_object.GetComponent<SpriteRenderer>();
            carrot_fallvegetable = carrot_object.GetComponent<FallVegetable>();
            zanCarrot_Child = carrot_object.transform.FindChild("Zan_Effct").gameObject;
            this.zanCarrot_animator = zanCarrot_Child.GetComponent<Animator>();
            this.zanCarrot_renderer = zanCarrot_Child.GetComponent<SpriteRenderer>();
            zanCarrot_renderer.enabled = false;
        }

        /********ポテト***************/
        if (vegiID == 0)
        {
            potato_object = gameObject;
            this.potato_animator = potato_object.GetComponent<Animator>();
            this.potatorenderer = potato_object.GetComponent<SpriteRenderer>();
            potato_fallvegetable = potato_object.GetComponent<FallVegetable>();
            zanPotato_Child = potato_object.transform.FindChild("Zan_Effct").gameObject;
            this.zanPotato_animator = zanPotato_Child.GetComponent<Animator>();
            this.zanPotato_renderer = zanPotato_Child.GetComponent<SpriteRenderer>();
            zanPotato_renderer.enabled = false;

            /***************************/
        }


        /*******オニオン************/
        if (vegiID == 2)
        {
            onion_object = gameObject;
            this.onion_animator = onion_object.GetComponent<Animator>();
            this.onionrenderer = onion_object.GetComponent<SpriteRenderer>();
            onion_fallvegetable = onion_object.GetComponent<FallVegetable>();
            zanOnion_Child = onion_object.transform.FindChild("Zan_Effct").gameObject;
            this.zanOnion_animator = zanOnion_Child.GetComponent<Animator>();
            this.zanOnion_renderer = zanOnion_Child.GetComponent<SpriteRenderer>();
            zanOnion_renderer.enabled = false;

            /***************************/
        }
    }
    // Update is called once per frame
    void Update()
    {



        /****共通****/
        // Debug.Log(delta+"制限時間");
        //Destroy(gameObject);
        /************/

        if (zanCarrot_fadeoutflg == true)
        {
            zanCarrot_renderer.transform.parent = null;
            carrot_fallvegetable.fallSpeed = cutfall_speed;
            this.delta += Time.deltaTime;
            if (this.delta > span)
            {

                zanCarrot_renderer.GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alfa);
                alfa += zanspeed;
                if (alfa < 0)
                {
                    Destroy_carrotzan();
                }
            }

        }


        if (zanPotato_fadeoutflg == true)
        {
            zanPotato_renderer.transform.parent = null;
            potato_fallvegetable.fallSpeed = cutfall_speed;


            this.delta += Time.deltaTime;
            if (this.delta > span)
            {

                zanPotato_renderer.GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alfa);
                alfa += zanspeed;
                if (alfa < 0)
                {
                    Destroy_potatozan();
                }
            }

        }

        if (zanOnion_fadeoutflg == true)
        {
            zanOnion_renderer.transform.parent = null;
            onion_fallvegetable.fallSpeed = cutfall_speed;
            this.delta += Time.deltaTime;
            if (this.delta > span)
            {

                zanOnion_renderer.GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alfa);
                alfa += zanspeed;
                if (alfa < 0)
                {
                    Destroy_onionzan();
                }
            }

        }


        /********にんじん***********/
        if (carrot_fadeoutflg == true)
        {
            this.delta += Time.deltaTime;
            if (this.delta > span)
            {

                carrotrenderer.GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alfa);
                alfa += speed;

            }
        }
        /***************************/

        /********ポテト*************/
        if (potato_fadeoutflg == true)
        {
            this.delta += Time.deltaTime;
            if (this.delta > span)
            {

                potatorenderer.GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alfa);
                alfa += speed;
            }
        }
        /**************************/


        /********オニオン*************/
        if (onion_fadeoutflg == true)
        {
            this.delta += Time.deltaTime;
            if (this.delta > span)
            {

                onionrenderer.GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alfa);
                alfa += speed;
            }
        }
        /****************************/


    }
    void Destroy_carrotzan()
    {
        Destroy(zanCarrot_Child);
        zanCarrot_fadeoutflg = false;
    }

    void Destroy_potatozan()
    {
        Destroy(zanPotato_Child);
        zanPotato_fadeoutflg = false;
    }

    void Destroy_onionzan()
    {
        Destroy(zanOnion_Child);
        zanOnion_fadeoutflg = false;
    }

}
