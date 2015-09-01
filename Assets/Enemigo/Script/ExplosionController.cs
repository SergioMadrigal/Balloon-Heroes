using UnityEngine;
using System.Collections;

public class ExplosionController : MonoBehaviour {
	

	// Use this for initialization
	void OnEnable () {

		GetComponent<ParticleSystem>().Play();
		Invoke("RecicleParticle",5f);

	}
	
	// Update is called once per frame
	void RecicleParticle () {
	
		ObjectPool.Instance.PoolGameObject(this.gameObject);
	}
}
