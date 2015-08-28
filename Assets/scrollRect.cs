using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scrollRect : MonoBehaviour {

	float xOrigin;

	// Use this for initialization
	void Start () {
		print ("W : " + Screen.width);
		xOrigin = Screen.width/2;
		GetComponent<RectTransform>().position = new Vector3(xOrigin,transform.position.y,transform.position.z);


	}
	
	// Update is called once per frame
	void Update () {
		float x = GetComponent<RectTransform>().position.x;
		print(x);
		x = Mathf.Clamp(x,0,xOrigin*2);

		GetComponent<RectTransform>().position = new Vector3(x,transform.position.y,transform.position.z);
	}
}
