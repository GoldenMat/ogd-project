using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {


    public Camera cam;
    private IEnumerator coroutineQ;
    private IEnumerator coroutineW;
    private IEnumerator coroutineR;

    public GameObject _shield;
    public GameObject _cono;
    public GameObject _taunt;


    private MeshRenderer _shieldMesh;
    private MeshRenderer _conoMesh;
    private MeshRenderer _tauntMesh;

    private MeshCollider _conoColl;
    private SphereCollider _tauntColl;
    private MeshCollider _shieldColl;


    public Material _CastingMaterialShield;
    public Material _SpellMaterialShield;
    private Renderer _materialShield;

    private Vector3 bas;


    // Use this for initialization
    void Start()
    {
        bas = new Vector3(0, 0, 0);


        _shieldMesh = _shield.GetComponent<MeshRenderer>();
        _conoMesh = _cono.GetComponent<MeshRenderer>();
        _tauntMesh = _taunt.GetComponent<MeshRenderer>();

        _conoColl = _cono.GetComponent<MeshCollider>();
        _tauntColl = _taunt.GetComponent<SphereCollider>();
        _shieldColl = _shield.GetComponent<MeshCollider>();

        _shieldMesh.enabled = false;
        _conoMesh.enabled = false;
        _tauntMesh.enabled = false;

        _materialShield = _shield.GetComponent<Renderer>();
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

            _taunt.transform.position = bas;

        }



        //if (Input.GetMouseButtonDown(0))

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _shieldMesh.enabled = true;

            //DebugExtension.DebugWireSphere(bas, 3f, 100, true);

        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            //_shieldMesh.enabled = false;

            _materialShield.material = _SpellMaterialShield;

            _shieldColl.enabled = true;

            coroutineQ = ShieldDuration(_shieldColl);
            StartCoroutine(coroutineQ);

        }




        //cono
        if (Input.GetKeyDown(KeyCode.W))
        {
            _conoMesh.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {

            //quando il mouse viene alzato disabilita la mesh renderer e abilita il collider
            _conoMesh.enabled = false;

            _conoColl.enabled = true;

            coroutineW = InstantStun(_conoColl);
            StartCoroutine(coroutineW);

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _tauntMesh.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            _tauntMesh.enabled = false;

            _tauntColl.enabled = true;

            //coroutineR = InstantDamage(_tauntColl);
            //StartCoroutine(coroutineR);
        }


    }

    public IEnumerator FieldDamageDuration()
    {
        yield return new WaitForSeconds(5.0f);
        _conoColl.enabled = false;

    }

    public IEnumerator ShieldDuration(Collider cast)
    {
        yield return new WaitForSeconds(5.0f);
        _shieldMesh.enabled = false;
        _materialShield.material = _CastingMaterialShield;
        cast.enabled = false;

    }

    public IEnumerator InstantStun(Collider stun)
    {
        yield return new WaitForSeconds(0.5f);
        stun.enabled = false;

    }



}





        //aggiungere tasto sinistro rifletti proiettili
        /*
        if (Input.GetMouseButtonDown(1))
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
                        intoExp.GetComponent<EnemyManager>().Stun();
                    }
                }

            }

        }*/


