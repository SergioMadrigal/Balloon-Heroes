using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler  {
	public static GameObject itemBrignDragged;
	Vector3 startPosition;
	Transform startParent;
	#region IBeginDragHandler implementation
	
	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBrignDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}
	
	#endregion

	#region IDragHandler implementation
	
	public void OnDrag (PointerEventData eventData)
	{ 
		transform.position = Input.mousePosition;
		Debug.Log("En posicion");


	}
	
	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		itemBrignDragged = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if(transform.parent != startParent){
			transform.position = startPosition;
			Debug.Log("Arrastrado");
		}

	}

	#endregion

}
