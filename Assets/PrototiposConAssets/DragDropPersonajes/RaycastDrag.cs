using UnityEngine;
using System.Collections;

public class RaycastDrag : MonoBehaviour {
	
	public RaycastHit hit_2;
	Animator anim;

	// Use this for initialization
	void Start () {
		StartCoroutine("MethodUpdate");
	}
	
	// Update is called once per frame
	IEnumerator MethodUpdate () {
		while(true){
			Debug.DrawRay(transform.position,
		              transform.TransformDirection(Vector3.forward)*20,
		              Color.yellow);
			yield return null;
		}
	}

	public void characterRaycasting(){
		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit_2,100)){
			if (hit_2.transform.gameObject.tag == "Slot"){
				hit_2.transform.gameObject.GetComponent<SlotCharacter>().actCharOnTable(gameObject.transform.parent.name);
				transform.parent.gameObject.SetActive(false);
			} else if (hit_2.transform.gameObject.tag == "SlotC"){
				hit_2.transform.gameObject.GetComponentInParent<SlotCharacter>().actCharOnTable(gameObject.transform.parent.name);
				transform.parent.gameObject.SetActive(false);
			} else { //if (hit_2.transform.gameObject.tag != "Slot" && hit_2.transform.gameObject.tag != "SlotC"){
				anim = gameObject.transform.parent.GetComponent<Animator>();
				anim.SetTrigger("Balloon");	
				//transform.parent.GetComponent<LoadNewCharDrag>().releaseDrag();
			}
		} 
	}
}
