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
		
		GameObject goes=(GameObject)ObjectPool.Instance.GetGameObjectOfType("Capsule");
		goes.transform.position = cañon1.position;
		goes.GetComponent<Rigidbody>().AddForce((destino - transform.position).normalized * speedBall,ForceMode.Impulse);
		audioSource.Play();
		GameObject canon = (GameObject)ObjectPool.Instance.GetGameObjectOfType("Capsule");
		canon.transform.position = cañon2.position;
		canon.GetComponent<Rigidbody>().AddForce((destino-transform.position).normalized * speedBall,ForceMode.Impulse);
		audioSource.Play();
	}

}
