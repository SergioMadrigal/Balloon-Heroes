using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class VideoIntro : MonoBehaviour {

	//private string movPath = "intro_monkey.mov";
	

	void Start() {

	//	Handheld.PlayFullScreenMovie (movPath, Color.black, FullScreenMovieControlMode.Full);
	//	print("Reproduciendo");

	}
	void Update(){
		DesaparecerIntro ();
	}
	
	void DesaparecerIntro(){

		if(Input.GetMouseButton(0)){
		//	((MovieTexture)GetComponent<Renderer> ().material.mainTexture).Pause();
		//	gameObject.SetActive(false);

		}
	}

}