using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllCubesGo : MonoBehaviour {

	public GameObject RedCube,BlueCube;
	private float range = 0.08f,Redjump = 0f,RedSucess = 0f, Redleftforce = 0f, Redrightforce = 0f,AllCubesX, AllSucces = 0f;
	private float Bluejump = 0f,BlueSucess = 0f, Blueleftforce = 0f, Bluerightforce = 0f,AllCubesY;
	public static float RedXPos, RedYPos,BlueXPos, BlueYPos;
	public bool RedLeft = Input.GetKey ("a"), RedRight = Input.GetKey ("d"), RedUp = Input.GetKey ("w");
	public bool BlueLeft = Input.GetKey ("[4]"), BlueRight = Input.GetKey ("[6]"), BlueUp = Input.GetKey ("[8]");

	void Update () {
		if(!Score.End){
			int index = 0, index2 = 0, index3 = 0, index4 = 0;
			RedLeft = Input.GetKey ("a");
			RedRight = Input.GetKey ("d");
			RedUp = Input.GetKey ("w");
			RedXPos = RedCube.transform.position.x;
			RedYPos = RedCube.transform.position.y;
			BlueLeft = Input.GetKey ("[4]");
			BlueRight = Input.GetKey ("[6]");
			BlueUp = Input.GetKey ("[8]");
			AllCubesX = RedCube.transform.position.x - BlueCube.transform.position.x;
			AllCubesY = RedCube.transform.position.y - BlueCube.transform.position.y;
			BlueXPos = BlueCube.transform.position.x;
			BlueYPos = BlueCube.transform.position.y;
				if (!RedLeft)
					Redleftforce = 0f;
				if (!RedRight)
					Redrightforce = 0f;
				if (!BlueLeft)
					Blueleftforce = 0f;
				if (!BlueRight)
					Bluerightforce = 0f;
				if (BlueLeft) {
					BlueXPos = BlueCube.transform.position.x - range;
				Blueleftforce += range;
				} 
				if (BlueRight) {
					BlueXPos = BlueCube.transform.position.x + range;
				Bluerightforce += range;
				}
				if (BlueSucess == 0f) {
					if (BlueUp) {
					if (index2 < 100) {
						BlueYPos = BlueCube.transform.position.y + range;
						index2++;
					} else {
						RedSucess = 50f;
						index2 = 0;
					}
					}
				}
				if (BlueSucess > 0) {
					BlueSucess--;
				}
				if (RedLeft) {
					RedXPos = RedCube.transform.position.x - range;
				Redleftforce += range;
				} 
				if (RedRight) {
					RedXPos = RedCube.transform.position.x + range;
				Redrightforce += range;
				}
				if (RedSucess == 0f) {
					if (RedUp) {
					index = 0;
					if (index < 100) {
						RedYPos = RedCube.transform.position.y + range;
						index++;
					} else {
						RedSucess = 50f;
						index = 0;
					}
					}
				}
				if (RedSucess > 0) {
					RedSucess--;
				}
			if (AllSucces == 0f) {
				if (AllCubesX <= 0.75f && AllCubesX >= -0.75f) {
					if(AllCubesY <= 0.75f && AllCubesY >= -0.75f){
						if(RedRight && !BlueRight && !BlueLeft && !BlueUp){
							BlueXPos = BlueXPos + Redrightforce * 1.5f;
							Redrightforce = 0f;
						}
						if (BlueRight && !RedRight && !RedLeft && !RedUp) {
							RedXPos = RedXPos + Bluerightforce * 1.5f;
							Bluerightforce = 0f;
						}
						if(RedLeft && !BlueRight && !BlueLeft && !BlueUp){
							BlueXPos = BlueXPos - Redleftforce * 1.5f;
							Redleftforce = 0f;
						}
						if (BlueLeft && !RedRight && !RedLeft && !RedUp) {
							RedXPos = RedXPos - Blueleftforce * 1.5f;
							Blueleftforce = 0f;
						}
						if(BlueLeft && RedRight){
							BlueXPos += Redrightforce;
							RedXPos -= Blueleftforce;
							Redrightforce = 0f;
							Blueleftforce = 0f;
						}
						if(BlueRight && RedLeft){
							BlueXPos -= Redleftforce;
							RedXPos += Bluerightforce;
							Redleftforce = 0f;
							Bluerightforce = 0f;
						}
						Redleftforce = 0f;
						Redrightforce = 0f;
						Blueleftforce = 0f;
						Bluerightforce = 0f;
						AllSucces = 50f;
					}
				}
			}
			if(AllSucces > 0f){
				AllSucces--;
				Redleftforce = 0f;
				Redrightforce = 0f;
				Blueleftforce = 0f;
				Bluerightforce = 0f;
			}
			RedCube.transform.position = new Vector3 (RedXPos, RedYPos, 0f);
			RedCube.transform.eulerAngles = new Vector3 (0f, 0f, 0f);
			if(RedCube.transform.position.y < -25f){
				RedCube.transform.position = new Vector3 (0f, 0f, 0f);
			}
			BlueCube.transform.position = new Vector3 (BlueXPos, BlueYPos, 0f);
			BlueCube.transform.eulerAngles = new Vector3 (0f, 0f, 0f);
			if(BlueCube.transform.position.y < -25f){
				BlueCube.transform.position = new Vector3 (0f, 0f, 0f);
			}
		}
	}
		
	}
