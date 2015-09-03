using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class healtEnemy : MonoBehaviour {

	public Image vida;
	public float health = 100;
	public float value;
	AudioSource audioSource;
	AudioClip clip;

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}
	void OnEnable () {
		Invoke("DestroyEnemy", 7f);
	}

	public void Damage(float value){
		health -= value*100;
		vida.fillAmount -= value;
		StartCoroutine(audioHealth());

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

	IEnumerator audioHealth(){
		audioSource.Play();
		yield return new WaitForSeconds(audioSource.clip.length);
		
	}
	
}
