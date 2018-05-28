using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support : MonoBehaviour
{

    public Camera cam;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            //Debug.Log ("Click Mouse");

            /*
			Vector3 pos = Input.mousePosition;
			pos.z = cam.nearClipPlane;

			Debug.Log ("Pos" + pos);
			pos = Camera.main.ScreenToWorldPoint (pos);
			pos.y = 0;
			Debug.Log ("PosDopoScale" + pos);
			*/

            Ray pos = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(pos.origin, pos.direction * 30, Color.yellow, 100);
            RaycastHit hit;

            if (Physics.Raycast(pos, out hit))
            {
                Vector3 bas = hit.collider.bounds.center;
                bas.y = 0;

                if (hit.collider.gameObject.tag == "Floor")
                {
                    bas = hit.point;
                }

                DebugExtension.DebugWireSphere(bas, 2.5f, 100, true);
                Collider[] Arround = Physics.OverlapSphere(bas, 2.5f);
                foreach (Collider intoExp in Arround)
                {
                    if (intoExp.transform.tag == "Enemy")
                    {
                        intoExp.GetComponent<BoxCollider>().transform.gameObject.SendMessage("AreaHeal");
                        //Debug.Log ("Message Sent");
                    }
                }

            }




        }


        //cono
        if (Input.GetMouseButtonDown(1))
        {


        }

    }


}
