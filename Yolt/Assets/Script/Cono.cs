using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cono : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll) {

        if (coll.gameObject.tag == "Enemy") {
            //coll.gameObject.GetComponent<Health>().TakeDamege(param)
            coll.transform.gameObject.SendMessage("ConeDamage");
        }

    }
}
