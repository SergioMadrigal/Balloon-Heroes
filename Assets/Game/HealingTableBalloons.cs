using UnityEngine;
using System.Collections;

public class HealingTableBalloons : MonoBehaviour {
	public TableLife table_life;
	// Use this for initialization
	void Start () {
		table_life = table_life.GetComponent<TableLife>();
		StartCoroutine("MethodUpdate");
	}
	
	// Update is called once per frame
	IEnumerator MethodUpdate () {
		while(true){

			if(gameObject.activeInHierarchy){
				if (table_life.percentage<100){
					yield return new WaitForSeconds(2);
					table_life.plusLife(2);
				} 
			}

			yield return null;
		}

	}
}
