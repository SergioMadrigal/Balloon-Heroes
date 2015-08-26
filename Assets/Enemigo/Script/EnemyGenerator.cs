using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

	public float timer = 5.0f;
	
	// Use this for initialization
	void Start () {


	}
	// Update is called once per frame
	void Update () {

			ObjectPool.Instance.GetGameObjectOfType("Enemigo");
			GameObject nuevo = ObjectPool.Instance.GetGameObjectOfType("Enemigo");
			nuevo.transform.position = new Vector3(Random.Range(-10.0F, 10.0F),Random.Range(-10.0F, 10.0F),0);			
	}
}
