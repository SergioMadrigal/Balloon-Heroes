using UnityEngine;
using System.Collections;

public class Globos : MonoBehaviour {

	public float timer = 15.0f;
	float valor = 100;
	//public GameObject marcador;

	void Update () {

		timer -= Time.deltaTime;

		if(timer<=0){
			timer = 0;
			print ("Tiempo terminado");
		}
	 
		
		}

	void OnMouseDown(){
		Destroy (gameObject);

		valor += + 100;
		print(valor);

	}
	
}
