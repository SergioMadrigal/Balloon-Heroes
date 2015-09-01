using UnityEngine;
using System.Collections;

public class camara : MonoBehaviour {

	// Use this for initialization
	void Start () {



		for (int i=0; i<50; i++) {
			GameObject objeto = ObjectPool.Instance.GetGameObjectOfType("Sphere 1");
			objeto.transform.position =(Vector3)Random.insideUnitSphere*Random.Range(1,10);  //.insideUnitSphere*Random.Range(1,10);  //.insideUnitCircle*Random.Range(1,100);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
