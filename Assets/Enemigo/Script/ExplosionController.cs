using UnityEngine;
using System.Collections;

public class ExplosionController : MonoBehaviour {

	AudioSource audioSource;
	AudioClip clip;

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}
	
	// Use this for initialization
	void OnEnable () {

		GetComponent<ParticleSystem>().Play();
		Invoke("RecicleParticle",5f);


	}
	
	// Update is called once per frame
	void RecicleParticle () {
	
		ObjectPool.Instance.PoolGameObject(this.gameObject);
	
	}

	IEnumerator audioExplosion(){
		audioSource.Play();
		yield return new WaitForSeconds(audioSource.clip.length);
		StartCoroutine(audioExplosion());
	}
}
