using UnityEngine;
using System.Collections;

public class Reciclador : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
	
		Invoke("DestroyEnemy",7f);

	}

	void OnCollisionEnter(Collision other){

		if(other.gameObject.tag == "TableCollider" ){
			other.gameObject.GetComponent<TableLife>().lessLife(5);
			DestroyEnemy();
		}
	}

	void DestroyEnemy(){
		ObjectPool.Instance.PoolGameObject(gameObject);
	}

}
