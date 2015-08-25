using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class LoadNewCharacter : MonoBehaviour {
	//var timer
	public float timeLimit = 0f;
	public Image timerImage;
	//public Text textCounter;
	
	private float timeLapse = 0f;
	private float timeFraction = 0f;

	//var buttons
	private bool butWithCharacter; //flag
	public Button[] characButtons;
	private int nRandom;


	// Use this for initialization
	void Start () {
		//Timer
		timerImage = timerImage.GetComponent<Image>() ;
		//textCounter = textCounter.GetComponent<Text>();

		timeFraction = timeLimit/80f;  //Divide time between 10
		timeLapse = Time.time + timeFraction;

		timeLimit = Time.time + timeLimit;

		timerImage.fillAmount = 0f;

		//buttons
		butWithCharacter = false;

		StartCoroutine("MethodUpdate");
	}
	

	// Update is called once per frame
	IEnumerator MethodUpdate () {

		while(true){

			if(!butWithCharacter)
				enableButton();

			timer ();

			//Chronometer
			//textCounter.text = Mathf.Round(Time.time).ToString() +"s";

			yield return null;
		}
	}

	//Timer
	private void timer(){
		if(timerImage.fillAmount < 1){
			if(Time.time > timeLapse){
				timerImage.fillAmount += 0.0125f;
				timeLapse = Time.time + timeFraction;
			}
		}
	}

	//enable Button with random character
	private void enableButton(){
		if(timerImage.fillAmount == 1){
			nRandom = Random.Range(0,3);

			Debug.Log(nRandom);
			switch(nRandom){
				case 0:
					characButtons[0].gameObject.SetActive(true) ;
					break;
				case 1:
					characButtons[1].gameObject.SetActive(true) ;
					break;
				case 2:
					characButtons[2].gameObject.SetActive(true) ;
					break;
				default:
					break;
			}

			butWithCharacter = true;
		}
	}

	//disable Button when is Pressed
	private void disableButtonPressed(Button buttonArg){
		buttonArg.enabled = false;
	}

}
