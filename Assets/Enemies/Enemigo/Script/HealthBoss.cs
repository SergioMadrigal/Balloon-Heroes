using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBoss : MonoBehaviour {

	public Image vida;
	public float health = 100;
	public float value;
	public AudioClip clip;
	public AudioSource finalSound;
	//public GameObject ScoreFinal = null;

	//void OnEnable () {
		//Invoke("DestroyEnemy", 7f);
//		StartCoroutine(DestroyEnemy());
	//}
	void Start(){
		//ScoreFinal = GameObject.Find("Score") as GameObject;
		//ScoreFinal = GetComponent<GameObject>();
		finalSound = GetComponent<AudioSource>();
		//ScoreFinal.SetActive(false);
	}

	
public void Damage(float value){
	health -= value*200;
	
	vida.fillAmount -= value;
	
	if(health <= 0){
		
		//print("Eliminado");
		ObjectPool.Instance.PoolGameObject(this.gameObject);
		//	StopCoroutine("EnemyTime");
		//	StartCoroutine("EnemyPeon");
			//ScoreFinal.SetActive(true);

	}
	
}
void DestroyEnemy(){
	
	ObjectPool.Instance.PoolGameObject(gameObject);
}

public void OnCollisionEnter(Collision nave){
	
	health -= value*100;
	
	vida.fillAmount -= value;
	
	if(health <=0){
		
		ObjectPool.Instance.PoolGameObject(this.gameObject);

	}
  } 
	IEnumerator audioStop(){

		finalSound.Stop();
		yield return new WaitForSeconds(finalSound.clip.length);
    }
}