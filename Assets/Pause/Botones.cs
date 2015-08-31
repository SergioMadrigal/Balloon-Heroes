using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Botones : MonoBehaviour {

	public GameObject pause;
	public GameObject ScoreFinal;
	public bool active;

	void Start(){
		active = true;
		pause.SetActive(false);
		ScoreFinal.SetActive(false);
	}

	public void freezePause(){

			if(active){
			active = true;
				pause.SetActive(true);
				Time.timeScale = 0;
			}
	}

    public void RepeatLevel(){
		Application.LoadLevel("Score");
		print("Reinicio");
	}
	public void ChangLevelTo(){
		Application.LoadLevel("bonus");
		print("Cambo");
	}
	public void RetryLevel(){
		Application.LoadLevel("Enemigo");
		Time.timeScale=1;
	}

	public void HomeLevel(){
		Application.LoadLevel("Menu");
		Time.timeScale = 1;
	}
	public void PlayLevel(){
		pause.SetActive(false);
		//	active = false;
		Time.timeScale = 1;

	}
}
