using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

public class LoadXmlFile : MonoBehaviour {
	public TextAsset file;

	// Use this for initialization
	void Start () {
		GetLevel ();
	}

	public void GetLevel(){
		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.LoadXml(file.text); // load the file.
		XmlNodeList levelsList = xmlDoc.GetElementsByTagName("level"); // array of the level nodes.

		//each level
		foreach (XmlNode levelInfo in levelsList){

			XmlNodeList levelcontent = levelInfo.ChildNodes;

			//each element in level
			foreach (XmlNode levelsItens in levelcontent){ // levels itens nodes.
				if(levelsItens.Name == "name"){
					Debug.Log("name :"+levelsItens.InnerText);
				}
				
				if(levelsItens.Name == "tutorial"){
					Debug.Log("tutorial :"+levelsItens.InnerText);
				}
				
				if(levelsItens.Name == "object"){
					Debug.Log("name :"+levelsItens.Attributes["name"].Value+ " " + levelsItens.InnerText);			
				}
				
				if(levelsItens.Name == "finaltext"){
					Debug.Log("finaltext :"+levelsItens.InnerText);
				}
			}
		}
	}

}
