using UnityEngine;
using System.Collections;

public class Personajes : MonoBehaviour {

	public GameObject selectSlot;
	public GameObject modelo;

	// Use this for initialization
	void Start () {
	
		modelo.SetActive(false);

	}
	
	// Update is called once per frame
	void OnMouse(){
   
		if(selectSlot){
			modelo.SetActive(true);
		}


	}
}
