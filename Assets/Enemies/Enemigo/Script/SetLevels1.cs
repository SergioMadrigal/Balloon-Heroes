using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class SetLevels1: MonoBehaviour {
	private float time0 = 0f;
	//public Text textCounter, textNameLevel, objectName;
	public GameObject alienPrefab,shipPrefab,alienRed,alienYellow,demolisherPrefab;
	public int current_level;
	public TextAsset file;

	private List<Enemy> objects;

	public Transform [] carriles;
	public Transform [] carrilesShip;

	AudioClip clip;
	AudioSource audioSource;

	private GameObject new_obj;
	private Enemy new_enemy;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		XmlNodeList levelList = getLevel();

		objects = new List<Enemy>();

		new_obj = null;
		new_enemy = null;

		foreach (XmlNode levelsItens in levelList){
			if(levelsItens.Name == "object"){
				if (levelsItens.Attributes["name"].Value == "alien") {
					//new_obj = ObjectPool.Instance.GetGameObjectOfType("alien");
					//new_obj.transform.position = carriles[Random.Range(0,carriles.Length-1)].position + (Vector3)Random.insideUnitCircle *Random.Range(1f,3f);  
					new_obj =Instantiate(alienPrefab,carriles[Random.Range(0,carriles.Length-1)].position + (Vector3)Random.insideUnitCircle *Random.Range(1f,1f),Quaternion.Euler(0,270,0)) as GameObject;

				} else if (levelsItens.Attributes["name"].Value == "Enemigo"){

					new_obj = Instantiate(shipPrefab,carrilesShip[Random.Range(0,carriles.Length-1)].position + (Vector3)Random.insideUnitCircle *Random.Range(1f,1f),Quaternion.Euler(0,270,0)) as GameObject;

					//new_obj = ObjectPool.Instance.GetGameObjectOfType("Enemigo");
					//new_obj.transform.position = carriles[Random.Range(0,carriles.Length-1)].position + (Vector3)Random.insideUnitCircle *Random.Range(1f,3f);
				} if(levelsItens.Attributes["name"].Value == "alien_peon_rojo"){

					new_obj =Instantiate(alienRed,carriles[Random.Range(0,carriles.Length-1)].position + (Vector3)Random.insideUnitCircle *Random.Range(1f,1f),Quaternion.Euler(0,270,0)) as GameObject;
				}
					else if(levelsItens.Attributes["name"].Value == "demolisher"){
					//audioSource.Play();
					new_obj = Instantiate(demolisherPrefab,carriles[Random.Range(0,carriles.Length-1)].position + (Vector3)Random.insideUnitCircle *Random.Range(1f,1f),Quaternion.Euler(0,270,0)) as GameObject;
				}

				new_enemy = new_obj.AddComponent<Enemy>() as Enemy;
			


				new_enemy.name = (string) levelsItens.Attributes["name"].Value;
				new_enemy.timeBirth = float.Parse(levelsItens.Attributes["time"].Value);
				
				objects.Add(new_enemy);
			}

			if(levelsItens.Name == "name"){
				//Debug.Log("name :"+levelsItens.InnerText);
			//	textNameLevel.text = levelsItens.InnerText;
			}
			
		} // end foreach(2)

		foreach(Enemy e in objects){
			e.gameObject.SetActive(false);
		}

		foreach(Enemy e in objects){
			StartCoroutine("bringToLife", e);
		}

		time0 = Time.time;

		//StartCoroutine("UpdateMethod");
	}
	
	
	// Update is called once per frame
	IEnumerator UpdateMethod () {
		while (true) {

			foreach(Enemy e in objects){
				if(!e.isActiveAndEnabled){
						if(Time.time > (time0 + e.timeBirth) ){
							e.gameObject.SetActive(true);
						}
				}
			}

			yield return null;
		}
	}

	IEnumerator bringToLife(Enemy enemyObj){
		yield return new WaitForSeconds(enemyObj.timeBirth);
		enemyObj.gameObject.SetActive(true);
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
