using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class healtEnemy : MonoBehaviour {
	//lifebar
	public Image vida;
	//Values
	public int health;
	private int totalHealth;
	//Audio
	AudioSource audioSource;
	AudioClip clip;



	void Start(){
		vida = vida.GetComponent<Image>();
		totalHealth = health;
		audioSource = GetComponent<AudioSource>();
	
	}

	//test
	public void Damage(int value){
		health -= value;

		if(vida.fillAmount > 0f )
			vida.fillAmount -= 0.07f;

		audioHealth();

		if(health <= 0f){

			DestroyEnemy();

		}
	}

	//Return to Object
	public void DestroyEnemy(){		
		Debug.Log ("SE MUERE ENEMIGO");
		this.gameObject.SetActive(false);
	}

	//Sound
	public void audioHealth(){
		audioSource.Play();
	}
	
}
