using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mori_LoadClear : MonoBehaviour {
	
	GameObject limitTimeUI;
	public float WaitChangeTime = 3.0f;
	public float WaitFadeTime = 3.0f;

	public float fadeSpeed = 0.01f;        //透明度が変わるスピードを管理
	float red, green, blue, alfa;   //パネルの色、不透明度を管理

	public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
	public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ

	Image fadeImage;                //透明度を変更するパネルのイメージ

	// Use this for initialization
	void Start () {
		fadeImage = GetComponent<Image> ();
		red = fadeImage.color.r;
		green = fadeImage.color.g;
		blue = fadeImage.color.b;
		alfa = fadeImage.color.a;

		this.limitTimeUI = GameObject.Find("LimitTime");
	}

	void Update (){
		//スペースキーを押すとクリアシーンに移動する
		if(Input.GetKeyDown(KeyCode.Space)){
			this.limitTimeUI.GetComponent<Text> ().text = "終了";

			this.WaitFadeTime -= Time.deltaTime;
			if (this.WaitFadeTime < 0) {
				StartFadeOut ();

				this.WaitChangeTime -= Time.deltaTime;
				if (this.WaitChangeTime < 0)
					SceneManager.LoadScene ("Mori_Clear");
			}
		}
		//左キーを押すとクリアシーンに移動する
		//if(Input.GetKeyDown(KeyCode.LeftArrow)){
		//	SceneManager.LoadScene ("Mori_Clear");
		//}
	}
	//Buttonをクリックするとクリアシーンに移動する
	//public void ButtonClicked(){
	//	SceneManager.LoadScene ("Mori_Clear");
	//}

	void StartFadeIn(){
		alfa -= fadeSpeed;                //不透明度を徐々に下げる
		SetAlpha ();                      //変更した不透明度パネルに反映する
		if(alfa <= 0){                    //完全に透明になったら処理を抜ける
			isFadeIn = false;             
			fadeImage.enabled = false;    //パネルの表示をオフにする
		}
	}

	void StartFadeOut(){
		fadeImage.enabled = true;  // パネルの表示をオンにする
		alfa += fadeSpeed;         // 不透明度を徐々にあげる
		SetAlpha ();               // 変更した透明度をパネルに反映する
		if(alfa >= 1){             // 完全に不透明になったら処理を抜ける
			isFadeOut = false;
		}
	}

	void SetAlpha(){
		fadeImage.color = new Color(red, green, blue, alfa);
	}

}
