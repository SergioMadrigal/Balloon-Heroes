using UnityEngine;
using System.Collections;

public class BotonesMenu : MonoBehaviour {

	AudioClip clip;
	AudioSource audioSource;

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}

	public void ChangeToPlay(){
	//	Application.LoadLevel ("Video");
		StartCoroutine(soundPlay());
	}

	public void ChangeToSkip(){
		Application.LoadLevel ("Seleccion");
	}

	IEnumerator soundPlay(){
		audioSource.Play();
		yield return new WaitForSeconds(audioSource.clip.length);
		Application.LoadLevel("Proto Game");    

	}

}
