﻿using UnityEngine;
using System.Collections;

public class camara : MonoBehaviour {
	public GameObject prefab;
	// Use this for initialization
	void Start () {
		for (int i=0; i<100; i++) {
			GameObject objeto = Instantiate(prefab) as GameObject;
			objeto.transform.position =(Vector3)Random.insideUnitCircle*Random.Range(1,20);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
