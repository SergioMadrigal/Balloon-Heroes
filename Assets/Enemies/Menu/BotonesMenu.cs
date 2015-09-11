using UnityEngine;
using System.Collections;

public class BotonesMenu : MonoBehaviour {

	AudioClip clip;
	AudioSource audioSource;
	//public string name;

	void Start(){
		audioSource = GetComponent<AudioSource>();
		Time.timeScale =1;
		//name = "intro_android_Xlarge.mp4";
	}

	public void ChangeToPlay(){
		Time.timeScale =1;
		StartCoroutine(soundPlay());
	}

	public void ChangeToSkip(){
		Time.timeScale =1;
		Application.LoadLevel ("Seleccion");
	}

	IEnumerator soundPlay(){
		audioSource.Play();
		Time.timeScale =1;
		yield return new WaitForSeconds(1);
		//Handheld.PlayFullScreenMovie(name,Color.black,FullScreenMovieControlMode.Full);
		Application.LoadLevel("levels");  



	}

}
