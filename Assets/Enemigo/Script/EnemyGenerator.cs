using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

	public float timer = 5.0f;
	
	// Use this for initialization
	void Start () {


	}
	// Update is called once per frame
	void Update () {
	
		timer -= Time.deltaTime;
		
		if(timer <= 0){
			timer = 0;
			ObjectPool.Instance.GetGameObjectOfType("Enemigo");
			GameObject nuevo = ObjectPool.Instance.GetGameObjectOfType("Enemigo");
			nuevo.transform.position = (Vector3)Random.insideUnitCircle*Random.Range(1,10);
			
		}

	}
}
