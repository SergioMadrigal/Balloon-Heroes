using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class CharacterButton : MonoBehaviour /*, IBeginDragHandler, IDragHandler, IEndDragHandler*/{
	public bool dragEnd = true;
	public bool isdragging = false;

	public static GameObject itemBrignDragged;
	public Animator characterModel;
	Vector3 startPosition;

	// Use this for initialization
	void Start (){
		dragEnd = true;
		isdragging = false;
	}

	/*
	public void OnBeginDrag(PointerEventData eventData){
		itemBrignDragged = characterModel.gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData){ 
		transform.position = Input.mousePosition;
		Debug.Log("En posicion");
	}

	public void OnEndDrag(PointerEventData eventData){
		itemBrignDragged = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if(transform.parent != startParent){
			transform.position = startPosition;
			Debug.Log("Arrastrado");
		}
	}*/

	/*
	//when is dragged
	void onMouseDrag(){
		dragEnd = false;
		isdragging = true;
		Debug.Log ("IsDragging");
	}*/

	/*
	//when the mouse drop the button
	void onMouseUpAsButton(){
		dragEnd = true;
		isdragging = false;
		Debug.Log ("IsNOTDragging");
	}*/

}
