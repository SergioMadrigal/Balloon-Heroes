using UnityEngine;
using System.Collections;

public class ActiveBalloon : MonoBehaviour {
	public GameObject balloon;

	// Use this for initialization
	void Start () {
		balloon.SetActive(false);
	}

	//activate animation with the Balloon object
	public void activeBalloon(){
		balloon.SetActive(true);
	}
	
	//deactivate object
	public void deactivateObject(){
		balloon.SetActive(false);
		gameObject.SetActive(false);
	}

}
