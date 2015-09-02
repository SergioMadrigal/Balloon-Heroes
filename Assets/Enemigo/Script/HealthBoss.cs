using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBoss : MonoBehaviour {

	public Image vida;
	public float health = 200;
	public float value;

	//void OnEnable () {
		//Invoke("DestroyEnemy", 7f);
//		StartCoroutine(DestroyEnemy());
	//}

	
public void Damage(float value){
	health -= value*100;
	
	vida.fillAmount -= value;
	
	if(health <= 0){
		
		GameObject posision = ObjectPool.Instance.GetGameObjectOfType("Explosion");
		
		posision.transform.position = transform.position;
		print("Eliminado");
		ObjectPool.Instance.PoolGameObject(this.gameObject);
	}
	
}
void DestroyEnemy(){
	
	ObjectPool.Instance.PoolGameObject(gameObject);
}

public void OnCollisionEnter(Collision nave){
	
	health -= value*100;
	
	vida.fillAmount -= value;
	
	if(health <=0){
		
		GameObject posision = ObjectPool.Instance.GetGameObjectOfType("Explosion");
		posision.transform.position = transform.position;
		ObjectPool.Instance.PoolGameObject(this.gameObject);
	}
  } 
}