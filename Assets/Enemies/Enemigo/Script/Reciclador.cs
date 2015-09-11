using UnityEngine;
using System.Collections;

public class Reciclador : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
	
		Invoke("DestroyThis",7f);

	}

	void OnCollisionEnter(Collision other){

		if(other.gameObject.tag == "TableCollider" ){
			other.gameObject.GetComponent<TableLife>().lessLife(5);
			DestroyThis();
		}
	}

	void DestroyThis(){
		ObjectPool.Instance.PoolGameObject(gameObject);
	}

}
