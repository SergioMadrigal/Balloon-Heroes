using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class healtEnemy : MonoBehaviour {

	public Scrollbar healthBar;
	public float health = 100;
	public float value;

	public void Damage(float value){
		health -= value;
		healthBar.size = health/100f;

	}

	void OnCollisionEnter(Collision other){

		health -= value;
		healthBar.size = health/100f;

	}
}
