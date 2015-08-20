using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public GameObject proyectil;
	// Use this for initialization
	void Start () {

		InvokeRepeating ("Ball1", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
		Destroy(proyectil);
	}
	

	void Ball1(){
	GameObject go=(GameObject)Instantiate (proyectil, transform.position, Quaternion.identity);
		go.GetComponent<Rigidbody>().velocity = new Vector3 (0,15,-100);

	}


}
