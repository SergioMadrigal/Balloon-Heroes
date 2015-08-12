using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class VideoIntro : MonoBehaviour {

	void Start() {
		((MovieTexture)GetComponent<Renderer> ().material.mainTexture).Play ();

	}
	void Update(){
//		DesaparecerIntro ();
	}
	
//	void DesaparecerIntro(){

//		if(Input.GetMouseButton(0)){
//			((MovieTexture)GetComponent<Renderer> ().material.mainTexture).Pause();
//			gameObject.SetActive(false);

//		}
//	}

//	public void Menu(){

//		GetComponent<Menu> ().OnGUI ();


//	}
}