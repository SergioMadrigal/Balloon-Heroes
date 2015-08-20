using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUp : MonoBehaviour {
	public Canvas popName;
	public bool tampil = false;

	public void TampilPopUp(){
		if(tampil == false){
			tampil = true;
			popName.enabled = true;

		} else if(tampil == true){
			tampil = false;
			popName.enabled = false;
		}
	}
}
