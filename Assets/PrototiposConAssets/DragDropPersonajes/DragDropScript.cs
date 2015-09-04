using UnityEngine;
using System.Collections;

public class DragDropScript : MonoBehaviour {

	private float dist;
	private Transform toDrag;
	private bool dragging;
	private Vector3 offset;

	private Ray ray;
	private RaycastHit hit;
	private Vector3 v3;

	private GameObject actHit;

	private Animator anim;

	// Use this for initialization
	void Start () {
		dragging = false;
		actHit = null;
		StartCoroutine("MethodUpdate");
	}

	// Update is called once per frame
	IEnumerator MethodUpdate() {
		while(true){

			//On drag enter
			if(Input.GetMouseButtonDown(0)){

				//Raycast 1 . From Camera
				ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

				//reference of raycast 1
				Debug.DrawRay(ray.origin,ray.direction*100,Color.blue);

				if(Physics.Raycast(ray,out hit, 100)){

					//Search for character in "UI layer" and dragging this when is founded
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

			//Is Dragging
			if (Input.GetMouseButton(0)){
				if (dragging){
					v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
					v3 = Camera.main.ScreenToWorldPoint(v3);
					toDrag.position = v3 + offset;
				}
			}

			//End Drag
			if (Input.GetMouseButtonUp(0)){
				if(actHit!=null){

					//Ask for Raycast 2. From Character dragged
					actHit.GetComponentInChildren<RaycastDrag>().characterRaycasting();

					if(actHit.tag == "Drag"){
						anim = hit.transform.gameObject.GetComponent<Animator>();
						anim.SetTrigger("Balloon");
						hit.transform.parent.GetComponent<LoadNewCharDrag>().releaseDrag();
					}
				}

				//finalizing drag
				actHit = null;
				dragging = false;
			}

			yield return null;
		
		}//end while
	}
}
