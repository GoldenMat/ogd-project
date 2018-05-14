using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody myRigidbody;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Camera mainCamera;
    private Vector3 PointToLook;

    public GunControler theGun;
    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        /* //soluzione con i quaternioni
        Plane playerplane = new Plane(Vector3.up, transform.position);
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.3f;
        if (playerplane.Raycast(cameraRay, out hitDist))
        {
            Vector3 targetPoint = cameraRay.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
        }
        */

        moveVelocity = moveInput * speed;
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundplane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundplane.Raycast(cameraRay, out rayLength))
        {
            Vector3 PointToLook = cameraRay.GetPoint(rayLength);
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
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        // Quando non tocco tasto, l'animazione si ferma. Da rividere
        if (Input.GetKey(KeyCode.None))
        {
            
        }


        /* //prove varie
        moveVelocity = moveInput * speed;
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundplane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundplane.Raycast(cameraRay, out rayLength))
        {
            Vector3 PointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, PointToLook, Color.red);
            transform.LookAt(new Vector3(PointToLook.x, transform.position.y, PointToLook.z));
           
        }
        */
        //Sparo
        if (Input.GetMouseButtonDown(0))
        {
            theGun.isFiring = true;
            GetComponent<CharacterMeshController>().Shoot();
        }
        if (Input.GetMouseButtonUp(0))
        {
            theGun.isFiring = false;
        }

      

    }
    
    public Vector3 Pointtolook()
    {
        return PointToLook;
    }
    
    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
    
}
