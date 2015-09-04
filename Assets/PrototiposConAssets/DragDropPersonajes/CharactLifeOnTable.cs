using UnityEngine;
using System.Collections;

public class CharactLifeOnTable : MonoBehaviour {
	public float lifeTime = 25.0f;
	public GameObject[] life_object ;

	private float timeWeak1, timeWeak2, timeWeak3;
	private float time;

	// Use this for initialization
	void Start () {
		/*
		timeWeak1 = (lifeTime/100) * 30 ;
		timeWeak2 = (lifeTime/100) * 60 ;
		timeWeak3 = lifeTime;

		time		=	Time.time;
		
		timeWeak1	+=	time;
		timeWeak2	+=	time;
		timeWeak3	+=	time;

		StartCoroutine("UpdateMethodLife");*/

		restartLife ();

	}
	
	// Update is called once per frame
	IEnumerator UpdateMethodLife() {
		while (true) {
				if(Time.time>timeWeak3){
					life_object[0].SetActive(false);
					life_object[1].SetActive(false);
					life_object[2].SetActive(false);
					transform.parent.GetComponent<Animator>().SetTrigger("Balloon");
					//gameObject.GetComponent<Animator>().SetTrigger("Balloon");
					StopCoroutine("UpdateMethodLife");
				} else if(Time.time>timeWeak2){
					life_object[0].SetActive(true);
					life_object[1].SetActive(false);
					life_object[2].SetActive(false);
				} else if(Time.time>timeWeak1){
					life_object[0].SetActive(true);
					life_object[1].SetActive(true);
					life_object[2].SetActive(false);
				}
				
				yield return null;
		}
	}

	public void restartLife(){
		timeWeak1 = (lifeTime/100) * 30 ;
		timeWeak2 = (lifeTime/100) * 60 ;
		timeWeak3 = lifeTime;

		life_object[0].SetActive(true);
		life_object[1].SetActive(true);
		life_object[2].SetActive(true);

		time		=	Time.time;
		
		timeWeak1	+=	time;
		timeWeak2	+=	time;
		timeWeak3	+=	time;

		//Debug.Log(timeWeak1+" "+timeWeak2+" "+timeWeak3);
		
		StartCoroutine("UpdateMethodLife");
	}
}
