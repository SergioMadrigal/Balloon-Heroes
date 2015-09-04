using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class healtEnemy : MonoBehaviour {
	//lifebar
	public Image vida;

	//Values
	public int health;
	private int totalHealth;
	//private int value;

	//Audio
	AudioSource audioSource;
	AudioClip clip;

	void Start(){
		vida = vida.GetComponent<Image>();

		totalHealth = health;
		audioSource = GetComponent<AudioSource>();

		StartCoroutine("MethodUpdate");

	}

	IEnumerator MethodUpdate(){
		while(true){
			//vida.fillAmount = health / totalHealth ; 

			/*if (vida.fillAmount <= 0){
				DestroyEnemy();
			}*/

			yield return null;
		}
	}

	//time of life
	void OnEnable () {
		//Invoke("DestroyEnemy", 7f);
	}

	//test
	public void Damage(int value){
		health -= value;

		if(vida.fillAmount > 0f )
			vida.fillAmount -= 0.04f;

		StartCoroutine(audioHealth());

		if(health <= 0f){
			DestroyEnemy();
		}
	}

	//Return to Object
	public void DestroyEnemy(){		
		//ObjectPool.Instance.PoolGameObject(gameObject);
		gameObject.SetActive(false);
	}

	//On Collision
	//public void OnCollisionEnter(Collision nave){
	//	Damage(value);
	//}

	//Sound
	IEnumerator audioHealth(){
		audioSource.Play();
		yield return new WaitForSeconds(audioSource.clip.length);
	}
	
}
