using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGhost : MonoBehaviour
{
    public float speed;
    private Camera mainCamera;
    private Vector3 PointToLook;

    // Use this for initialization
    void Start()
    {
        
        mainCamera = FindObjectOfType<Camera>();
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundplane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundplane.Raycast(cameraRay, out rayLength))
        {
            PointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, PointToLook, Color.red);
            transform.LookAt(new Vector3(PointToLook.x, transform.position.y, PointToLook.z));

        }
        //per evitare movimenti indesiderati, prendo solo il WASD
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }

    }

    public Vector3 Pointtolook()
    {
        return PointToLook;
    }

}

