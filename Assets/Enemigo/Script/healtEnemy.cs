using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class healtEnemy : MonoBehaviour {

	public Scrollbar healthBar;
	public float health = 100;
	public float value;

	void OnEnable () {
		Invoke("DestroyEnemy", 7f);
	}

	public void Damage(float value){
		health -= value;
		healthBar.size = health/100f;

		if(health <= 0){

			print("Eliminado");
			ObjectPool.Instance.PoolGameObject(this.gameObject);
		}

	}
	void DestroyEnemy(){
		
		ObjectPool.Instance.PoolGameObject(gameObject);
	}
	
}
