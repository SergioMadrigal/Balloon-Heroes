	using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class SetLevels1: MonoBehaviour {
	private float time0 = 0f;
	public Text textCounter, textNameLevel, objectName;
	public GameObject cubePrefab, spherePrefab;
	public int current_level;
	public TextAsset file;

	private List<Enemy> objects;

	// Use this for initialization
	void Start () {
		textCounter.text = "0" ;

		XmlNodeList levelList = getLevel();

		objects = new List<Enemy>();

		GameObject new_obj = null;
		Enemy new_enemy = null;

		foreach (XmlNode levelsItens in levelList){
			if(levelsItens.Name == "object"){
				if (levelsItens.Attributes["name"].Value == "alien_peon") { //Si es cubo
					new_obj = Instantiate(cubePrefab,new Vector3(0,8,0),Quaternion.identity) as GameObject;
				} else if (levelsItens.Attributes["name"].Value == "Enemigo"){ //Si es esfera
					new_obj = Instantiate(spherePrefab,new Vector3(0,8,0),Quaternion.identity) as GameObject;
				}

				new_enemy = new_obj.AddComponent<Enemy>() as Enemy;

				new_enemy.name = (string) levelsItens.Attributes["name"].Value;
				new_enemy.timeBirth = float.Parse(levelsItens.Attributes["time"].Value);
				
				objects.Add(new_enemy);
			}

			if(levelsItens.Name == "name"){
				//Debug.Log("name :"+levelsItens.InnerText);
				textNameLevel.text = levelsItens.InnerText;
			}
			
		} // end foreach(2)

		foreach(Enemy e in objects){
			e.gameObject.SetActive(false);
		}

		time0 = Time.time;

		StartCoroutine("UpdateMethod");
	}
	
	// Update is called once per frame
	IEnumerator UpdateMethod () {
		while (true) {
			textCounter.text = Mathf.Round(Time.time).ToString() +"s";

			foreach(Enemy e in objects){
				if(!e.isActiveAndEnabled){
					if(Time.time > (time0 + e.timeBirth) ){
						e.gameObject.SetActive(true);
						objectName.text = e.name+" ("+e.timeBirth+").";
					}
				}
			}

			yield return null;
		}
	}

	//Read file and search for elements in current level
	public XmlNodeList getLevel(){
		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.LoadXml(file.text); // load the file.
		XmlNodeList levelsList = xmlDoc.GetElementsByTagName("level"); // array of the level nodes.

		XmlNodeList currentLevelList = null;

		//search level
		foreach (XmlNode levelInfo in levelsList){
			if(levelInfo.Attributes["lv"].Value == current_level.ToString()){

				currentLevelList = levelInfo.ChildNodes;
				
			} // end if
		
		} // end foreach 

		//test
		/*if(currentLevelList != null){
			foreach (XmlNode levelsItens in currentLevelList){
				if(levelsItens.Name == "name"){
					//Debug.Log("name :"+levelsItens.InnerText);
					textNameLevel.text = levelsItens.InnerText;
				}
				
				if(levelsItens.Name == "object"){
					Debug.Log("name object :"+levelsItens.Attributes["name"].Value+" tiempo :"
					          +levelsItens.Attributes["time"].Value);
				}
				
			} // end foreach(2)
		
		} // end if*/

		return currentLevelList;
	}
}
