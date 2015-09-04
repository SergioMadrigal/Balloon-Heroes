using UnityEngine;
using System.Collections;

public class DragDropScript_bckup : MonoBehaviour {

	private float dist;
	private Transform toDrag;
	private bool dragging;
	private Vector3 offset;

	private Ray ray; // ray_2;
	private RaycastHit hit;// hit_2;
	private Vector3 v3;

	private GameObject actHit;

	//private Transform point;

	private Animator anim;

	// Use this for initialization
	void Start () {
		dragging = false;
		actHit = null;
		StartCoroutine("MethodUpdate");
	}

	//update per frame
	IEnumerator MethodUpdate() {
		while(true){

			if(Input.GetMouseButtonDown(0)){

				ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
				//Vector3 v3;

				Debug.DrawRay(ray.origin,ray.direction*100,
				              Color.blue);

				if(Physics.Raycast(ray,out hit, 100)){

					if(hit.transform.gameObject.tag == "Drag"){
						toDrag = hit.transform;
						dist = hit.transform.position.z - Camera.main.transform.position.z;
						v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
						v3 = Camera.main.ScreenToWorldPoint(v3);
						offset = toDrag.position - v3;
						dragging = true;
						actHit = hit.transform.gameObject;
					}
				}
			}

			if (Input.GetMouseButton(0)){
				if (dragging){
					v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
					v3 = Camera.main.ScreenToWorldPoint(v3);
					toDrag.position = v3 + offset;
				}
			}

			if (Input.GetMouseButtonUp(0)){
				if(actHit!=null){
					/*if( actHit.GetComponentInChildren<RaycastDrag>().hit_2.transform.tag == "Slot" ||
					  	actHit.GetComponentInChildren<RaycastDrag>().hit_2.transform.tag == "SlotC" ){
					*/			
						actHit.GetComponentInChildren<RaycastDrag>().characterRaycasting();
					/*	
					} else {

						anim = actHit.GetComponent<Animator>();
						anim.SetTrigger("Balloon");
						
					}*/

					if(actHit.tag == "Drag"){
						//if(hit.transform.gameObject.tag == "Drag"){
						anim = hit.transform.gameObject.GetComponent<Animator>();
						anim.SetTrigger("Balloon");
					}
				}

				/*
				if(hit.transform.gameObject.tag == "Drag"){
					hit.transform.gameObject.GetComponentInChildren<RaycastDrag>().characterRaycasting();
					//point = hit.transform;
					/*if(Physics.Raycast(point.position, point.TransformDirection(Vector3.left), out hit_2, 100f)){
						if (hit_2.transform.gameObject.tag == "Slot"){
							hit_2.transform.gameObject.GetComponent<SlotCharacter>().actCharOnTable(hit.transform.gameObject.name);
						} else if (hit_2.transform.gameObject.tag == "SlotC"){
							hit_2.transform.gameObject.GetComponentInParent<SlotCharacter>().actCharOnTable(hit.transform.gameObject.name);
						}
						
					
					} else {
						anim = hit.transform.gameObject.GetComponent<Animator>();
						anim.SetTrigger("Balloon");
					}* /
				}*/



				/*
				if(actHit.tag == "Drag"){
				//if(hit.transform.gameObject.tag == "Drag"){
					anim = hit.transform.gameObject.GetComponent<Animator>();
					anim.SetTrigger("Balloon");
				}*/
				
				actHit = null;
				dragging = false;
			}

			yield return null;
		}
	}
}
