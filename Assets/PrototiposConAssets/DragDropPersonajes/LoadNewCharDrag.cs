using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class LoadNewCharDrag : MonoBehaviour {

	//var timer
	public float timeLimit = 0f;
	public Image timerImage;

	private float timeLapse = 0f;
	private float timeFraction = 0f;

	//var generate buttons
	private bool butWithCharacter; //flag
	public GameObject[] characDrags;
	private Vector3[] initPositions;

	private GameObject actualButton;

	private int nRandom;

	void Awake(){
		initPositions = new Vector3[characDrags.Length];

		int i=0;
		foreach (GameObject g in characDrags) {
			initPositions[i] = g.gameObject.GetComponent<Transform>().localPosition;
			i++;
		}
	}

	// Use this for initialization
	void Start () {
		//Timer
		timerImage = timerImage.GetComponent<Image>();

		timeFraction = timeLimit/80f;  //Divide time between 10

		//initialize values
		resetVariables();

		StartCoroutine("MethodUpdate");
	}
	

	// Update is called once per frame
	IEnumerator MethodUpdate () {
		while(true){
			//if button isn't enable
			if(!butWithCharacter)
				enableButton();

			//time to enable the button
			timer ();

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
			//Debug.Log(nRandom);

			characDrags[nRandom].gameObject.SetActive(true);
			characDrags[nRandom].transform.localPosition = initPositions[nRandom];
			actualButton = characDrags[nRandom] as GameObject;

			butWithCharacter = true;
		}
	}

	//reset variables
	private void resetVariables(){
		timeLapse = Time.time + timeFraction;
		timeLimit = Time.time + timeLimit;
		timerImage.fillAmount = 0f;
		
		//buttons
		butWithCharacter = false;
		actualButton = null;
	}

	public void releaseDrag(){
		resetVariables();
	}

}
