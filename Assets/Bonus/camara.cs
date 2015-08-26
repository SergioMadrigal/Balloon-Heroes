using UnityEngine;
using System.Collections;

public class camara : MonoBehaviour {
	public GameObject prefab;
	public GameObject prefabBall;
	// Use this for initialization
	void Start () {



		for (int i=0; i<100; i++) {
			GameObject objeto = Instantiate(prefab) as GameObject;
			objeto.transform.position =(Vector3)Random.onUnitSphere*Random.Range(1,10);  //.insideUnitSphere*Random.Range(1,10);  //.insideUnitCircle*Random.Range(1,100);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
