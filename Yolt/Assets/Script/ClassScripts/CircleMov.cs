using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CircleMov : MonoBehaviour {

    private Transform _playerTransform;

    public GameObject _player;

    private float m_horizontal;
    public float speed;


	// Use this for initialization
	void Start () {
        speed = 150;
        _playerTransform = _player.GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {

        m_horizontal = Math.Sign(Input.GetAxis("Horizontal"));
        
        transform.RotateAround(_playerTransform.position, Vector3.up, speed * Time.deltaTime * m_horizontal);
		
	}
}
