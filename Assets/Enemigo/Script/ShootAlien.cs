using UnityEngine;
using System.Collections;

public class ShootAlien : MonoBehaviour {

	public Transform balaPeon;
	public Vector3 destino;
	public float speedBall = 50;
	public void ShootPeon(){

		GameObject go=(GameObject)ObjectPool.Instance.GetGameObjectOfType("Sphere 1");
		go.transform.position = balaPeon.position;
		go.GetComponent<Rigidbody>().AddForce(  (destino - transform.position).normalized * speedBall,ForceMode.Impulse);


	}
}
