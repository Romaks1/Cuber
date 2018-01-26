using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public GameObject RedCube, BlueCube;
	private float Red = 0, Blue = 0;
	public Text RedScore, BlueScore, RedWin, BlueWin, Nicha;
	public static bool End = false;

	void Update () {
		if(StartGame.Clicked && !End){
			if(RedCube.transform.position.y < -25f){
				Blue++;
				BlueScore.text = Blue.ToString ();
			}

			if(BlueCube.transform.position.y < -25f){
				Red++;
				RedScore.text = Red.ToString ();
			}
			StartCoroutine (Win());
		}
	}

	IEnumerator Win(){
		if (!End){
		if(Blue == 3f || Red ==3f){
			yield return new WaitForSeconds (1f);
			while(true){
				RedCube.transform.position = new Vector3 (-2f,-0.5f,0f);
				BlueCube.transform.position = new Vector3 (2f,-0.5f,0f);
				RedCube.GetComponent<AllCubesGo> ().enabled = false;
				BlueCube.GetComponent<AllCubesGo> ().enabled = false;
					End = true;
			if(Blue == 3f && Red == 3f){
				Nicha.gameObject.SetActive (true);
					break;
			}
			if(Blue == 3f){
				BlueWin.gameObject.SetActive (true);
					break;
			}
			if(Red == 3f){
				RedWin.gameObject.SetActive (true);
					break;
			}
			}
	}
	}
}
}