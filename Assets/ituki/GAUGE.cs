using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GAUGE : MonoBehaviour {

    //画像をゲームオブジェクトとして扱うための
    GameObject image1;
    
    //定数
    const int MAX = 60;//切られた物の上限値
    const int MIN =  0;//切られた物の下限値

    const int ADD = 3;
    const int DEC = 1;

    public int gauge1;//切られた個数

    // Use this for initialization
    void Start () {
        gauge1 = MIN;
        image1 = GameObject.Find("GAUGE");//ゲージ画像を見つける

        image1.GetComponent<Image>().fillAmount = MIN;//FillAmontの値を0にし、空の状態を作る

    }

    // Update is called once per frame
    void Update() {
        if (gauge1 < MIN) { gauge1 = MIN; }//範囲指定
        if (gauge1 > MAX) { gauge1 = MAX; }//範囲指定

        image1.GetComponent<Image>().fillAmount = (float)gauge1 / MAX;//ゲージのFillAmountをfloatで求める。gauge=MAXで満タン。

        if (Input.GetKeyDown(KeyCode.UpArrow)) { gauge1 += ADD; }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { gauge1 -= DEC; }

        //表示用プログラムと計算式は完成。
        /*
        続いては切った個数をgauge1に格納する。
        外部変数などを用いて数値を入れなければいけない。
        */
    }
}
