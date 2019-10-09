using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mori_LoadTitele : MonoBehaviour {

	//スペースキーを押すとタイトルシーンに移動する
	void Update (){
		if(Input.GetKeyDown(KeyCode.Space)){
			SceneManager.LoadScene ("Mori_Titele");
		}
	}

	//Buttonをクリックするとタイトルシーンに移動する
	public void ButtonClicked(){
		SceneManager.LoadScene ("Mori_Titele");
	}
}
