using UnityEngine;
using System.Collections;

public class ShootAlien : MonoBehaviour {

	public Transform balaPeon;
	public Vector3 destino;
	public float speedBall = 50;
	AudioSource audioSource;
	AudioClip clip;

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}

	public void ShootPeon(){

		GameObject gos=(GameObject)ObjectPool.Instance.GetGameObjectOfType("Capsule");
		gos.transform.position = balaPeon.position;
		gos.GetComponent<Rigidbody>().AddForce((destino - transform.position).normalized * speedBall,ForceMode.Impulse);
		StartCoroutine(audioShoot());
	}

	IEnumerator audioShoot(){
		audioSource.Play();
		yield return new WaitForSeconds(audioSource.clip.length);

	}


}
