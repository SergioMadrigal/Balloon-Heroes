using UnityEngine;
using System.Collections;

public class BotonesMenu : MonoBehaviour {

	public void ChangeToPlay(int sceneToChangeTo){
		
		Application.LoadLevel ("Video");

	}
	public void ChangeToFB(int sceneToChangeToFB){
		
		Application.LoadLevel ("Game");
		
	}
	public void ChangeToShop(int sceneToChangeToShop){
		
		Application.LoadLevel ("Game");
		
	}
	public void ChangeToSkip(int sceneToChangeToSkip){
		
		Application.LoadLevel ("Seleccion");
		
	}
}
