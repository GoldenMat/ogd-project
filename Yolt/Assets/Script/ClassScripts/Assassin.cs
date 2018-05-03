using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin : MonoBehaviour
{

    public Camera cam;
    private IEnumerator coroutine;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

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
                        intoExp.GetComponent<Health>().TakeDamage(10);
                    }
                }

            }




        }


        //cono
        if (Input.GetMouseButtonDown(1))
        {
            //appena clicka il mouse prende la mesh renderer del cono e la abilita
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;

        }

        if (Input.GetMouseButtonUp(1))
        {

            //quando il mouse viene alzato disabilita la mesh renderer e abilita il collider
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;

            transform.GetChild(0).GetComponent<MeshCollider>().enabled = true;

            coroutine = FieldDamageDuration(transform.GetChild(0));
            StartCoroutine(coroutine);
            
            
        }

    }

    public IEnumerator FieldDamageDuration(Transform figlio){
        yield return new WaitForSeconds(5.0f);
        figlio.GetComponent<MeshCollider>().enabled = false;

    }


}
