using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    private Ray cameraRay;
    private Camera myCamera;
    private float rayLength;
    private Vector3 PointToLook { get; set; }
    public GameObject groundPlane;

    #region MonoBehaviour Callbakcs
    private void Start()
    {
        myCamera = Camera.main;
        // a way to found the groundPlane in the scene
    }

    private void Update()
    {
        cameraRay = myCamera.ScreenPointToRay(Input.mousePosition);

        if (groundPlane.GetComponent<Plane>().Raycast(cameraRay, out rayLength))
        {
            PointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, PointToLook, Color.red);
            transform.LookAt(new Vector3(PointToLook.x, transform.position.y, PointToLook.z));
        }
    }
    #endregion

}
