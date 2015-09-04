using UnityEngine;
using System.Collections;

public class SlotCharacter : MonoBehaviour {
	public GameObject[] arrayCharacters;

	public GameObject actualCharacter;

	// Use this for initialization
	void Start () {
		actualCharacter = null;
	}

	//New character on the table
	public void actCharOnTable(string nameC){
		foreach(GameObject g in arrayCharacters){
			if(!g.activeInHierarchy && g.gameObject.name == nameC){
				sustCharOnTable();
				g.SetActive(true);
				g.GetComponent<Animator>().SetTrigger("onTable");
				g.GetComponentInChildren<CharactLifeOnTable>().restartLife();
				actualCharacter = g;
				break;
			}
		}
	}

	//Actual character is gone if exists in scene
	public void sustCharOnTable(){
		if(actualCharacter != null){
			actualCharacter.GetComponent<Animator>().SetTrigger("Balloon");
		}
	}

	//Active animation Balloon when the time for the actual character is over
	public void dieCharOnTable(){
		actualCharacter.GetComponent<Animator>().SetTrigger("Balloon");
		actualCharacter = null;
	}

	//Active dance
	public void happyCharacter(){
		if(actualCharacter != null){
			actualCharacter.GetComponent<Animator>().SetTrigger("Dance");
		}
	}
}
