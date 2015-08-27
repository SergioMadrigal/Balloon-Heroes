using UnityEngine;
using System.Collections;

public class Reciclador : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
	
		Invoke("DestroyEnemy",7f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){

		if(other.gameObject.tag == "Player" ){
		ObjectPool.Instance.PoolGameObject(this.gameObject);
		}
	}

	void DestroyEnemy(){
		
		ObjectPool.Instance.PoolGameObject(gameObject);
	}

}
