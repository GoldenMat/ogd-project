using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin : MonoBehaviour
{

    public Camera cam;
    private IEnumerator coroutineQ;
    private IEnumerator coroutineW;
    private IEnumerator coroutineR;

    public GameObject _sfera;
    public GameObject _cono;
    public GameObject _laserone;
    

    private MeshRenderer _sferaMesh;
    private MeshRenderer _conoMesh;
    private MeshRenderer _laseroneMesh;

    private MeshCollider _conoColl;
    private CapsuleCollider _laseroneColl;
    private SphereCollider _sferaColl;


    private Material _materialSfera;

    private Vector3 bas;


    // Use this for initialization
    void Start()
    {
        bas = new Vector3(0, 0, 0);


        _sferaMesh = _sfera.GetComponent<MeshRenderer>();
        _conoMesh = _cono.GetComponent<MeshRenderer>();
        _laseroneMesh = _laserone.GetComponent<MeshRenderer>();

        _conoColl = _cono.GetComponent<MeshCollider>();
        _laseroneColl = _laserone.GetComponent<CapsuleCollider>();
        _sferaColl = _sfera.GetComponent<SphereCollider>();

        _sferaMesh.enabled = false;
        _conoMesh.enabled = false;
        _laseroneMesh.enabled = false;

        
        _materialSfera = _sfera.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Ray pos = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(pos.origin, pos.direction * 30, Color.yellow, 1);
        RaycastHit hit;

        if (Physics.Raycast(pos, out hit))
        {
            /*bas = hit.collider.bounds.center;
            bas.y = 0;

            if (hit.collider.gameObject.tag == "Floor")
            {
                bas = hit.point;
            }*/

            bas = hit.point;
            bas.y = 0;
            _sfera.transform.position = bas;

        }



        //if (Input.GetMouseButtonDown(0))

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _sferaMesh.enabled = true;

            //DebugExtension.DebugWireSphere(bas, 3f, 100, true);

        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            /*//animation con durata, o particellare
            _materialSfera.color = Color.red;

            Collider[] Arround = Physics.OverlapSphere(bas, 3f);
            foreach (Collider intoExp in Arround)
            {
                if (intoExp.transform.tag == "Enemy")
                {
                    intoExp.GetComponent<Health>().TakeDamage(10);
                }
            }

            coroutineQ = SferaDamageDuration();
            StartCoroutine(coroutineQ);
            */

            _sferaMesh.enabled = false;

            _sferaColl.enabled = true;

            coroutineQ = InstantDamage(_sferaColl);
            StartCoroutine(coroutineQ);

        }




        //cono
        if (Input.GetKeyDown(KeyCode.W))
        {
            //appena clicka il mouse prende la mesh renderer del cono e la abilita
            _conoMesh.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {

            //quando il mouse viene alzato disabilita la mesh renderer e abilita il collider
            _conoMesh.enabled = false;

            _conoColl.enabled = true;

            coroutineW = FieldDamageDuration();
            StartCoroutine(coroutineW);

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _laseroneMesh.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            _laseroneMesh.enabled = false;

            _laseroneColl.enabled = true;

            coroutineR = InstantDamage(_laseroneColl);
            StartCoroutine(coroutineR);
        }


    }

    public IEnumerator FieldDamageDuration(){
        yield return new WaitForSeconds(5.0f);
        _conoColl.enabled = false;

    }
    
    public IEnumerator InstantDamage(Collider cast)
    {
        yield return new WaitForSeconds(0.5f);
        cast.enabled = false;

    }



}
