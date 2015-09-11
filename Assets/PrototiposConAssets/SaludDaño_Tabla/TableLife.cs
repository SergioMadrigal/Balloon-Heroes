using UnityEngine;
using System.Collections;

public class TableLife : MonoBehaviour {
	//GUI
	public Transform barlife;
	
	public float min	=	-347f;
	public float max	=	-48.8f;
	
	public int percentage = 100;

	// public Text per_Text;

	//Table GameObject
	public GameObject phase1, phase2, phase3, phase4, phase5;
	private GameObject[] lifePhases;
	public GameObject gameOverIm;
	public bool gameOver;
	AudioClip clip;
	AudioSource audioSource;
	

	// Use this for initialization
	void Start (){
		audioSource = GetComponent<AudioSource>();
		Time.timeScale =1;
		gameOverIm.SetActive(false);
		gameOver = false;
		lifePhases = new GameObject[]{phase1,phase2,phase3, phase4, phase5};
		StartCoroutine("UpdateMethod");
	}
	
	// Update is called once per frame
	IEnumerator UpdateMethod () {
		while(true){
			//print actual position
			//Debug.Log(barlife.localPosition.x);
			checkLife();
			
			if(Input.GetKey(KeyCode.DownArrow)){
				lessLife(1);
			} 
			
			if(Input.GetKey(KeyCode.UpArrow)){
				plusLife(1);
			}
			
			yield return null;
		}
	}

	public void lessLife(int value){
		if(barlife.localPosition.x > min){
			//barlife.Translate(-3,0,0);
			barlife.localPosition = new Vector3(barlife.localPosition.x-(3*value),0,0);
			percentage-= value;
			audioSource.Play();
			//per_Text.text=percentage +"%";
		}
	}

	public void plusLife(int value){
		if(barlife.localPosition.x < max){
			//barlife.Translate(3,0,0);
			barlife.localPosition = new Vector3(barlife.localPosition.x+(3*value),0,0);
			percentage+= value;
			//per_Text.text=percentage +"%";
		}
	}

	private void checkLife(){
		if(percentage>80){
			phase1Method();
		} else if(percentage < 80 && percentage > 60){
			phase2Method();
		} else if(percentage < 60 && percentage > 40){
			phase3Method();
		} else if(percentage < 40 && percentage > 20){
			phase4Method();
		} else if(percentage < 20 && percentage > 0){
			phase5Method();
		} else if(percentage <= 0){
			phaseGameOverMethod();
		}
	}

	private void phase1Method(){
		foreach(GameObject ph_ in lifePhases){
			ph_.SetActive(true);
		}
		gameOver = false;
	}

	private void phase2Method(){
		lifePhases[0].SetActive(true);
		lifePhases[1].SetActive(true);
		lifePhases[2].SetActive(true);
		lifePhases[3].SetActive(true);
		lifePhases[4].SetActive(false);
		gameOver = false;
	}

	private void phase3Method(){
		lifePhases[0].SetActive(true);
		lifePhases[1].SetActive(true);
		lifePhases[2].SetActive(true);
		lifePhases[3].SetActive(false);
		lifePhases[4].SetActive(false);
		gameOver = false;
	}

	private void phase4Method(){
		lifePhases[0].SetActive(true);
		lifePhases[1].SetActive(true);
		lifePhases[2].SetActive(false);
		lifePhases[3].SetActive(false);
		lifePhases[4].SetActive(false);
		gameOver = false;
	}

	private void phase5Method(){
		lifePhases[0].SetActive(true);
		lifePhases[1].SetActive(false);
		lifePhases[2].SetActive(false);
		lifePhases[3].SetActive(false);
		lifePhases[4].SetActive(false);
		gameOver = false;
	}

	private void phaseGameOverMethod(){
		lifePhases[0].SetActive(false);
		lifePhases[1].SetActive(false);
		lifePhases[2].SetActive(false);
		lifePhases[3].SetActive(false);
		lifePhases[4].SetActive(false);
		gameOver = true;
		gameOverImage();
	
	}

	public void gameOverImage(){
		Time.timeScale = 0.1f;
		gameOverIm.SetActive(true);
	}


}
