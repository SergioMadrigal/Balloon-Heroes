using UnityEngine;
using System.Collections;

public class Reciclador : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){

		if(other.gameObject.tag == "Player" ){
		ObjectPool.Instance.PoolGameObject(this.gameObject);
		}
		if(other.gameObject.tag != "Payer"){
			//Destroy(this.gameObject,5f);	
		}
	}
}
