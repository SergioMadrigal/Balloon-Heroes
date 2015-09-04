using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

	public Texture2D[] Sponsors; //Arreglo de imagenes
	public float StayTime = 2f;  // Tiempo que estara en pantalla 
	public string LevelAfterSponsors = "Menu"; //String de mombre de siguiente escena
	
	private float imageAlpha = 0f;
	private bool reachEnd = false;
	private int currentSponsor = 0;
	
	private bool shouldFadeIn = true;  //animacion de inicio
	private bool shouldFadeOut = false; //animacion de termino
	private bool requestedLevel = false;
	
	void Update()
	{
		if (Sponsors.Length == 0 || reachEnd == true)
		{
			if (!requestedLevel)
			{
				requestedLevel = true;
				reachEnd = true;
				Application.LoadLevel(LevelAfterSponsors);
				return;
			}
		}
	}
	
	IEnumerator WaitTime()
	{
		yield return new WaitForSeconds(StayTime);
		shouldFadeOut = true;
	}
	
	void fadeIn()
	{
		if (!shouldFadeIn)
			return;
		
		imageAlpha = Mathf.Lerp(imageAlpha, 1f, Time.deltaTime * 0.65f);
		
		if (imageAlpha > 0.99)
		{
			shouldFadeIn = false;
			StartCoroutine(WaitTime());
		}
	}
	
	void fadeOut()
	{
		if (!shouldFadeOut)
			return;
		
		imageAlpha = Mathf.Lerp(imageAlpha, 0f, Time.deltaTime * 1.5f);
		
		if (imageAlpha <= 0.02f)
		{
			shouldFadeOut = false;
			StartCoroutine(NextSponsor());
		}
	}
	
	IEnumerator NextSponsor()
	{
		yield return new WaitForSeconds(0.2f);
		if ((currentSponsor + 1) < Sponsors.Length)
		{
			shouldFadeIn = true;
			currentSponsor += 1;
		}
		else
		{
			reachEnd = true;
		}
	}
	
	void ShowImage()
	{
		GUI.depth = 0;
		GUI.color = new Color(GUI.color.r, GUI.color.b, GUI.color.g, imageAlpha);
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Sponsors[currentSponsor], ScaleMode.ScaleToFit, true, 1.0F);
	}
	
	void OnGUI()
	{
		if (Sponsors.Length > 0 && !reachEnd)
		{
			fadeIn();
			ShowImage();
			fadeOut();
		}
	}
}