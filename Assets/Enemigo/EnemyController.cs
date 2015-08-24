using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public float speed = 2;
	public float speedBall = 100;
	public Vector3 destino;

	void Start () {
		StartCoroutine("Shoot");

	}

	void Disp(){

		GameObject go=(GameObject)ObjectPool.Instance.GetGameObjectOfType("Sphere 1");
		go.transform.position = transform.position;


		//GameObject seguir = GameObject.FindWithTag("Player");
	


		go.GetComponent<Rigidbody>().AddForce(  (destino - transform.position).normalized * speedBall,ForceMode.Impulse);
	//	print((seguir.transform.position - transform.position).normalized);


	}

	IEnumerator Shoot(){

		Disp();
		yield return new WaitForSeconds(speed);
		StartCoroutine("Shoot");


	}




}
