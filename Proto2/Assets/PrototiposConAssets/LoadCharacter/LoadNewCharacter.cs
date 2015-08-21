using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class LoadNewCharacter : MonoBehaviour {

	public Image timerImage ;
	//public Button buttonDog, buttonBunny, buttonTurtle;

	// Use this for initialization
	void Start () {
		timerImage = GetComponent<Image>() ;

		StartCoroutine("activeButton");
		StartCoroutine("MethodUpdate");
	}
	
	// Update is called once per frame
	IEnumerator MethodUpdate () {
		while(true){



			yield return null;
		}
	}
	
	//Timer for activate character Button
	IEnumerator activeButton(){

		timerImage.fillAmount = 0;

		while(timerImage.fillAmount < 1f){
			Debug.Log (timerImage.fillAmount);
			timerImage.fillAmount += 0.1f;
		}

		timerImage.fillAmount = 0;

		yield return null;
	}

	//disable Button when is Pressed
	private void disableButtonPressed(Button buttonArg){
		buttonArg.enabled = false;
	}

}
