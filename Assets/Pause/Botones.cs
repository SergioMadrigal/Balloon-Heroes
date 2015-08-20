using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Botones : MonoBehaviour {

	public Canvas pause;
	public Canvas ScoreFinal;
	public bool active;

	void Start(){
		pause.enabled = false;
		ScoreFinal.enabled = false;
	}

	void Update(){

		if(Input.GetKey(KeyCode.Q)){

			if(active){
				active = true;
				print("Activado");
				pause.enabled = true;
			}else{
				active = false;
				print("Desactivado");
				pause.enabled = false;
			}

		}
		if(Input.GetKey(KeyCode.A)){

			ScoreFinal.enabled = true;

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
