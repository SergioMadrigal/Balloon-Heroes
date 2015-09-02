using UnityEngine;
using System.Collections;

public class ShootBoss : MonoBehaviour {

	public Transform cañon1;
	public Transform cañon2;
	public Vector3 destino;
	public float speedBall = 50;
	AudioSource audioSource;
	AudioClip clip;
	
	void Start(){
		audioSource = GetComponent<AudioSource>();
	}
	
	public void ShootBossGun(){
		
		GameObject go=(GameObject)ObjectPool.Instance.GetGameObjectOfType("proyectil boss");
		go.transform.position = cañon1.position;
		go.GetComponent<Rigidbody>().AddForce((destino - transform.position).normalized * speedBall,ForceMode.Impulse);

		GameObject canon = (GameObject)ObjectPool.Instance.GetGameObjectOfType("proyectil boss");
		canon.transform.position = cañon2.position;
		canon.GetComponent<Rigidbody>().AddForce((destino-transform.position).normalized * speedBall,ForceMode.Impulse);

		StartCoroutine(audio());
	}
	
	IEnumerator audio(){
		audioSource.Play();
		yield return new WaitForSeconds(audioSource.clip.length);
		
	}
	
	
}
