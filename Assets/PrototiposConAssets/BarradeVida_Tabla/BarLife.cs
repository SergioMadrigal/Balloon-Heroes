using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarLife : MonoBehaviour {
	public Transform barlife;

	public float min	=	-347f;
	public float max	=	-48.8f;

	public int percentage = 100;
	//public Text per_Text;
	
	// Use this for initialization
	void Start () {
		StartCoroutine("UpdateMethod");
	}
	
	// Update is called once per frame
	IEnumerator UpdateMethod () {
		while(true){
			//print actual position
			Debug.Log(barlife.localPosition.x);

			if(Input.GetKey(KeyCode.DownArrow)){
				if(barlife.localPosition.x > min){
					//barlife.Translate(-3,0,0);
					barlife.localPosition = new Vector3(barlife.localPosition.x-3,0,0);
					percentage--;
					//per_Text.text=percentage +"%";
				}
			} 

			if(Input.GetKey(KeyCode.UpArrow)){
				if(barlife.localPosition.x < max){
					//barlife.Translate(3,0,0);
					barlife.localPosition = new Vector3(barlife.localPosition.x+3,0,0);
					percentage++;
					//per_Text.text=percentage +"%";
				}
			}

			yield return null;
		}
	}
}
