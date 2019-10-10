using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mori_LoadMain : MonoBehaviour {

	//スペースキーを押すとメインシーンに移動する
	void Update (){
		if(Input.GetKeyDown(KeyCode.Space)){
			SceneManager.LoadScene ("Mori_Main");
		}
	}

	//Buttonをクリックするとメインシーンに移動する
	/*public void ButtonClicked(){
		SceneManager.LoadScene ("Mori_Main");
	}*/
}
