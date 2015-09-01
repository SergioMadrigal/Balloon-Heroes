using UnityEngine;
using System.Collections;

public class Globos : MonoBehaviour {

	public float timer = 15.0f;
	int valor = 100;
	public GameObject [] ballons;

	//public GameObject marcador;

	void Update () {

		timer -= Time.deltaTime;

		if(timer<=0){
			timer = 0;
			print ("Tiempo terminado");
		}
	}

	void OnMouseDown(){

		
		Score.score += valor;
		print(Score.score);

		Destroy (gameObject);

	}



	
	
}
