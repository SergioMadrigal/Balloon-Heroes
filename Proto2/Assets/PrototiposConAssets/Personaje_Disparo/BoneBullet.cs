using UnityEngine;
using System.Collections;

public class BoneBullet : MonoBehaviour {
	public float speed = 0.01f;
	public Transform point;

	// Use this for initialization
	void Start () {
		transform.position = point.position;
		StartCoroutine("MethodUpdate");
	}
	
	// Update is called once per frame
	IEnumerator MethodUpdate () {
		while(true){
			transform.Translate(speed,0,0);

			yield return null;
		}
	}
}
