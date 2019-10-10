using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mori_LoadOver : MonoBehaviour {

	//スペースキーを押すとオーバーシーンに移動する
	void Update (){
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			SceneManager.LoadScene ("Mori_Over");
		}
	}

	//Buttonをクリックするとオーバーシーンに移動する
	public void ButtonClicked(){
		SceneManager.LoadScene ("Mori_Over");
	}
}
