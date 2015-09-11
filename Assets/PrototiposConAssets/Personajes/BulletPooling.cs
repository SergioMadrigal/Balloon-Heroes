using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPooling : MonoBehaviour {
	public GameObject bullet;
	public Transform shootPoint;

	public int number_Bullets;

	public List<GameObject> _bullets;
	AudioClip clip;
	AudioSource audioSource;

	//public AudioSource rabbitSound;


	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		//rabbitSound = GetComponent<AudioSource>();
		instantiateBullets();
	}

	//Instantiate Array List of Bullets
	void instantiateBullets(){
		for(int i=0;i<number_Bullets;i++){
			_bullets.Add(Instantiate(bullet, shootPoint.transform.position, Quaternion.identity) as GameObject );
			_bullets[i].SetActive(false);
		}
	}

	//active Bullets
	public void activeBullet(){
		int i=0;

		while(_bullets[i].active){
			i++;
		}
			
		_bullets[i].SetActive(true);
		_bullets[i].GetComponent<Bullet>().backToLife();
		_bullets[i].transform.position = shootPoint.transform.position;
		//if(gameObject.name == "Danger"){
			audioSource.Play();
		//} 
		//if(gameObject.name == "Frankie"){
		//	rabbitSound.Play();
		//}

	}
}
