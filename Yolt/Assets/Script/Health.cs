using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int _health;

	// Use this for initialization
	void Start () {
		_health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void AreaDamage(){
		_health -= 10;

		//Debug.Log ("Health: " + _health);
	}

	void AreaHeal(){
		_health += 20;
	}

    public void TakeDotDamage() { }

    public void TakeDamage(int dam) {
        _health -= dam;
    }


}
