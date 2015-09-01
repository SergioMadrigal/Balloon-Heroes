using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Botones : MonoBehaviour {

	public GameObject pause;
	public GameObject ScoreFinal;
	public bool active;
	AudioSource audioSource;
	AudioClip clip;

	void Start(){
	
		active = true;
		pause.SetActive(false);
		ScoreFinal.SetActive(false);
		audioSource = GetComponent<AudioSource>();
	}

	public void freezePause(){
		if(active){
			active = true;
			audioSource.Play();
				pause.SetActive(true);
				Time.timeScale = 0;
			}
	}
	public void RetryLevel(){
		audioSource.Play();
	//	Application.LoadLevel("Enemigo");
		Time.timeScale=1;
		StartCoroutine(playSondRetry());

	}
	
	public void HomeLevel(){
		//audioSource.Play();
	//	Application.LoadLevel("Menu");
		Time.timeScale = 1;
		StartCoroutine(playSound());
	}
	public void PlayLevel(){
		audioSource.Play();
		pause.SetActive(false);
		Time.timeScale = 1;
		
	}
    public void RepeatLevel(){
		Application.LoadLevel("Score");
		print("Reinicio");
	}
	public void ChangLevelTo(){
		Application.LoadLevel("bonus");
		print("Cambo");
	}

	 IEnumerator playSound(){
		audioSource.Play();
		yield return new WaitForSeconds(audioSource.clip.length);
		Application.LoadLevel("Menu");    
		//StartCoroutine(playSound());
	}

	IEnumerator playSondRetry(){
		audioSource.Play();
		yield return new WaitForSeconds(audioSource.clip.length);
		Application.LoadLevel("Enemigo");



	}
}
