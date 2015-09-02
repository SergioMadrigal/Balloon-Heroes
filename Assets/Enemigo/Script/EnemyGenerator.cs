using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

	public float timer = 5.0f;
	public int contador =0;

	public Transform [] carriles;
	public Transform [] carrilesPeon;

	// Use this for initialization
	void Start () {
 
		StartCoroutine(EnemyTime());
		StartCoroutine(EnemyPeon());
	
	}
	// Update is called once per frame
	//void Update () {			
	//}

	IEnumerator EnemyTime(){



		yield return new WaitForSeconds(7);
		GameObject nuevo = ObjectPool.Instance.GetGameObjectOfType("Enemigo");
		nuevo.transform.position =  carriles[Random.Range(0,carriles.Length-1)].position + (Vector3)Random.insideUnitCircle *Random.Range(1f,3f);   //new Vector3(Random.Range(5.0F, 5.0F),Random.Range(-5.0F, 10.0F),0);

		nuevo.GetComponentInChildren<EnemyController>().ActivityStart();
			StartCoroutine(EnemyTime());

		
	}

	IEnumerator EnemyPeon(){
		yield return new WaitForSeconds(5);
		GameObject peon = ObjectPool.Instance.GetGameObjectOfType("alien_peon");
		peon.transform.position = carrilesPeon[Random.Range(0,carriles.Length-1)].position + (Vector3)Random.insideUnitCircle *Random.Range(1f,3f);//new Vector3(Random.Range(1.0F, 1.0F),Random.Range(-5.0F, 10.0F),0);
			
		StartCoroutine(EnemyPeon());
	}


}
