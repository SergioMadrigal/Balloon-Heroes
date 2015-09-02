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

		GameObject go=(GameObject)ObjectPool.Instance.GetGameObjectOfType("Sphere 1");
		go.transform.position = balaPeon.position;
		go.GetComponent<Rigidbody>().AddForce((destino - transform.position).normalized * speedBall,ForceMode.Impulse);
		StartCoroutine(audio());
	}

	IEnumerator audio(){
		audioSource.Play();
		yield return new WaitForSeconds(audioSource.clip.length);

	}


}
