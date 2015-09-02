using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public float speed = 2;
	public float speedBall = 100;
	public Vector3 destino;
	AudioSource audioSource;
	AudioClip clip;

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}
	public void ActivityStart () {
		StartCoroutine(Shoot());
	}

	void Disp(){


		GameObject go=(GameObject)ObjectPool.Instance.GetGameObjectOfType("Sphere 1");
		go.transform.position = transform.position;
		go.GetComponent<Rigidbody>().AddForce(  (destino - transform.position).normalized * speedBall,ForceMode.Impulse);

	}

	IEnumerator Shoot(){

		Disp();
		yield return new WaitForSeconds(speed);
		StartCoroutine(Shoot());
		StartCoroutine(audio());
	}

	IEnumerator audio(){
		audioSource.Play();
		yield return new WaitForSeconds(audioSource.clip.length);

	}

}
