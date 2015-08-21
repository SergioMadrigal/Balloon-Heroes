using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public GameObject proyectil;
	public GameObject target;
	void Start () {

		InvokeRepeating ("Ball", 1, 1);
	}

	void Ball(){
	GameObject go=(GameObject)Instantiate (proyectil, transform.position, Quaternion.identity);
		go.GetComponent<Rigidbody>().velocity = new Vector3 (0,0,-500);

		Vector3 nuevo = target.transform.position - proyectil.transform.position;

	}


}
