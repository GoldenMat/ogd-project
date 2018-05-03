using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private static float _lùth;
    private float _maxlùth;

	// Use this for initialization
	void Start () {

        _lùth = 0;

        _maxlùth = 10;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncreaseLùth(int i) {

        _lùth+=i;

        Debug.Log(_lùth);

        if (_lùth == _maxlùth) {


            //cambia tag in class che scegli
            //cambia mesh renderer in class che scegli
            
        }

    }
}
