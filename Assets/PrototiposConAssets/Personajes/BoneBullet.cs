using UnityEngine;
using System.Collections;

public class BoneBullet : MonoBehaviour {
	public float speed = 0.5f;
	public Transform point;

	public float timeLife = 5f;
	private float deadTime;

	// Use this for initialization
	void Start () {
		transform.position = point.position;

		deadTime = Time.time + timeLife;

		StartCoroutine("MethodUpdate");
	}
	
	// Update is called once per frame
	IEnumerator MethodUpdate () {
		while(true){
			transform.Translate(speed,0,0);

			areThisLiving();

			yield return null;
		}
	}

	void areThisLiving(){
		if(Time.time>deadTime){
			gameObject.SetActive(false); 
		}
	}
}
