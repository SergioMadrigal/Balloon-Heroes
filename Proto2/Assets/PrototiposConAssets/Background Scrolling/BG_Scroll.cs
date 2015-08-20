using UnityEngine;
using System.Collections;

public class BG_Scroll : MonoBehaviour {

	public float speed = 0.5f;
	// Use this for initialization
	void Start () {
		StartCoroutine("UpdateMethod");
	}
	
	// Update is called once per frame
	IEnumerator UpdateMethod () {
		while(true){
			Vector2 offset = new Vector2(Time.time*speed,0);

			gameObject.GetComponent<Renderer>().material.mainTextureOffset = offset;

			yield return null;
		}
	}
}
