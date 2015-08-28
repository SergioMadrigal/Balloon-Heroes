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
				pause.SetActive(true);
				active = true;
				Time.timeScale = 0;
			}//else{
			//	pause.SetActive(true);
			//	active = true;
			//	Time.timeScale = 0;
			//}

			//if (active) {
				
			//	ScoreFinal.SetActive(false);
			//	active = false;
				
			//}else		 {
			//	ScoreFinal.SetActive(true);
			//	active = true;
			//}
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
		pause.SetActive(false);
			active = false;
		Time.timeScale = 1;

	}
}
