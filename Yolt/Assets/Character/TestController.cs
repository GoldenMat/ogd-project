using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour {

	public float Speed;
	Vector3 _speed;
	public Camera camera;


	// Use this for initialization
	void Start () {
		_speed = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		_speed = new Vector3(Input.GetAxis("Horizontal"),0f, Input.GetAxis("Vertical"));
		transform.position += _speed*Time.deltaTime * Speed;
		Vector3 p = new Vector3();
        Camera  c = camera;
        Event   e = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        //mousePos.x = e.mousePosition.x;
        //mousePos.y = c.pixelHeight - e.mousePosition.y;
		mousePos = Input.mousePosition;

        p = c.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));
		//Debug.Log("hit in "+ mousePos);
		RaycastHit hit;
		if(Physics.Raycast(c.transform.position, p-c.transform.position, out hit, Mathf.Infinity)){
			
			transform.forward = (hit.point - transform.position).normalized;
		}
		GetComponent<CharacterMeshController>().characterTransform = transform;
		GetComponent<CharacterMeshController>().inputDirection = _speed;
		GetComponent<CharacterMeshController>().speed = Speed;
		if(Input.GetKeyDown("space")){
			GetComponent<CharacterMeshController>().Shoot();
		}
	}
}
