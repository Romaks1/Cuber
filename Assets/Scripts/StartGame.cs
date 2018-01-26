using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartGame : MonoBehaviour {

	public Text GameName, playTxt, RedScore, BlueScore;
	public GameObject  Pole, RedCube, BlueCube, Detect;

	public static bool Clicked;

	void OnMouseDown () {
		
	}
		
	void OnMouseUp () {
		if (!Clicked) {
			Clicked = true;
			playTxt.gameObject.SetActive (false);
			GameName.gameObject.SetActive (false);
			RedScore.gameObject.SetActive (true);
			BlueScore.gameObject.SetActive (true);
			Pole.gameObject.SetActive (true);
			RedCube.GetComponent <Animation> ().Play ("RedCubeStart");
			BlueCube.GetComponent <Animation> ().Play ("BlueCubeStart");
			RedCube.AddComponent <Rigidbody> ();
			BlueCube.AddComponent <Rigidbody> ();
			RedCube.GetComponent <AllCubesGo> ().enabled = true;
			BlueCube.GetComponent <AllCubesGo> ().enabled = true;
			Detect.gameObject.SetActive (false);
		}
	}
}
