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

	void Update(){

		if(Input.GetKeyDown(KeyCode.Q)){

			if(active){
				pause.SetActive(false);
				active = false;
				Time.timeScale = 1;
			}else{
				pause.SetActive(true);
				active = true;
				Time.timeScale = 0;
			}

		}
		if(Input.GetKeyDown(KeyCode.A)){

			if (active) {
				
				ScoreFinal.SetActive(false);
				active = false;
				
			}else		 {
				ScoreFinal.SetActive(true);
				active = true;
			}

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
		Application.LoadLevel("");
	}

	public void HomeLevel(){
		Application.LoadLevel("");
	}
	public void PlayLevel(){
		Time.timeScale = 1;

	}
}
