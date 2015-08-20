using UnityEngine;
using System.Collections;

public class CharacterLife : MonoBehaviour {
	public float lifeTime;
	public GameObject[] life_object ;

	private float timeWeak1, timeWeak2, timeWeak3;
	private float time;

	// Use this for initialization
	void Start () {

		timeWeak1 = (lifeTime/100) * 30 ;
		timeWeak2 = (lifeTime/100) * 60 ;
		timeWeak3 = lifeTime;

		StartCoroutine("UpdateMethod");

		time		=	Time.time;

		timeWeak1	+=	time;
		timeWeak2	+=	time;
		timeWeak3	+=	time;

		Debug.Log(timeWeak1+ " "+ timeWeak2+ " "+ timeWeak3);
	}
	
	// Update is called once per frame
	IEnumerator UpdateMethod () {
		while (true) {
				if(Time.time>timeWeak3){
					life_object[0].SetActive(false);
					life_object[1].SetActive(false);
					life_object[2].SetActive(false);
					Debug.Log("Muere mascota");
					Debug.Log("Activar animacion globo con personaje");
				} else if(Time.time>timeWeak2){
					life_object[0].SetActive(true);
					life_object[1].SetActive(false);
					life_object[2].SetActive(false);
				} else if(Time.time>timeWeak1){
					life_object[0].SetActive(true);
					life_object[1].SetActive(true);
					life_object[2].SetActive(false);
				}

				if(Time.time>timeWeak3+2){
					gameObject.SetActive(false);
					Debug.Log("Desaparecio");
				}

				yield return null;
		}
	}
}
