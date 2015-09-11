using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	public string name;
	// Use this for initialization
	void Start () {
		name = "intro_android_Xlarge.mp4";
	}
	
	// Update is called once per frame
	void Update () {
		Handheld.PlayFullScreenMovie(name,Color.black,FullScreenMovieControlMode.Full);
	}
}
