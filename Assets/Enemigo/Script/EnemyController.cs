using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public float speed = 2;
	public float speedBall = 100;
	public Vector3 destino;

	public void ActivityStart () {
		StartCoroutine("Shoot");
		//Invoke("DestroyEnemy", 7f);
	}

	void Disp(){

		GameObject go=(GameObject)ObjectPool.Instance.GetGameObjectOfType("Sphere 1");
		go.transform.position = transform.position;
	//	GameObject seguir = GameObject.FindWithTag("Player");
		go.GetComponent<Rigidbody>().AddForce(  (destino - transform.position).normalized * speedBall,ForceMode.Impulse);

	}

	IEnumerator Shoot(){
		Disp();
		yield return new WaitForSeconds(speed);
		StartCoroutine("Shoot");
	}

}
