using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 0.25f;
	
	public float timeLife = 3f;
	private float deadTime;
	
	// Use this for initialization
	void Start () {		
		deadTime = Time.time + timeLife;
		
		StartCoroutine("MethodUpdate");
	}
	
	// Update is called once per frame
	IEnumerator MethodUpdate () {
		while(true){

			areThisLiving();

			transform.Translate(speed,0,0);

			yield return null;
		}

	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "EnemyCollider"){
			col.gameObject.GetComponent<healtEnemy>().Damage(1);
			gameObject.SetActive(false);
			
		}
	}


	public void areThisLiving(){
		if(Time.time > deadTime){
			gameObject.SetActive(false); 
		}
	}

	public void backToLife(){
		deadTime = Time.time + timeLife;
		StartCoroutine("MethodUpdate");
	}
}
