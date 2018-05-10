﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support : MonoBehaviour
{
    public Camera cam;
    private IEnumerator coroutineQ;
    private IEnumerator coroutineW;
    private IEnumerator coroutineR;
    private IEnumerator coroutineCasting;
    private IEnumerator coroutineCasting1;

    public GameObject _slow;
    public GameObject _redemption;
    public GameObject _taric;


    private MeshRenderer _slowMesh;
    private MeshRenderer _redemptionMesh;
    private MeshRenderer _taricMesh;

    private SphereCollider _redemptionColl;
    private SphereCollider _taricColl;
    private CapsuleCollider _slowColl;

    private bool visibileRedemption = false;
    private bool visibileTaric = false;

    private Material _materialslow;

    private Vector3 bas;


    // Use this for initialization
    void Start()
    {
        bas = new Vector3(0, 0, 0);


        _slowMesh = _slow.GetComponent<MeshRenderer>();
        _redemptionMesh = _redemption.GetComponent<MeshRenderer>();
        _taricMesh = _taric.GetComponent<MeshRenderer>();

        _redemptionColl = _redemption.GetComponent<SphereCollider>();
        _taricColl = _taric.GetComponent<SphereCollider>();
        _slowColl = _slow.GetComponent<CapsuleCollider>();

        _slowMesh.enabled = false;
        _redemptionMesh.enabled = false;
        _taricMesh.enabled = false;


        //_materialslow = _slow.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Ray pos = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(pos.origin, pos.direction * 30, Color.yellow, 1);
        RaycastHit hit;

        if (Physics.Raycast(pos, out hit))
        {
            bas = hit.point;
            bas.y = 0;
            _redemption.transform.position = bas;
            _taric.transform.position = bas;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _slowMesh.enabled = true;
            
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            _slowMesh.enabled = false;

            _slowColl.enabled = true;

            coroutineQ = FieldSlowDuration(_slowColl);
            StartCoroutine(coroutineQ);

        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            //appena clicka il mouse prende la mesh renderer del redemption e la abilita
            _redemptionMesh.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {

            //quando il mouse viene alzato disabilita la mesh renderer e abilita il collider
            _redemptionMesh.enabled = false;

            coroutineCasting = CastingDuration(_redemptionColl, 3.0f, visibileRedemption);
            StartCoroutine(coroutineCasting);
            
        }

        if (visibileRedemption)
        {
            coroutineW = Instant(_redemptionColl, visibileRedemption);
            StartCoroutine(coroutineW);
        }



        if (Input.GetKeyDown(KeyCode.R))
        {
            _taricMesh.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            _taricMesh.enabled = false;

            _taricColl.enabled = true;

            coroutineCasting1 = Instant(_taricColl, visibileTaric);
            StartCoroutine(coroutineCasting1);
        }

        if (visibileTaric)
        {
            coroutineR = Instant(_taricColl, visibileTaric);
            StartCoroutine(coroutineR);
        }


    }

    public IEnumerator FieldSlowDuration(Collider slow)
    {   
        //per quanto tempo resta per terra lo slow
        yield return new WaitForSeconds(5.0f);
        slow.enabled = false;

    }

    public IEnumerator Instant(Collider cast, bool vis)
    {
        
        yield return new WaitForSeconds(0.5f);
        cast.enabled = false;
        vis = false;
        

    }

    public IEnumerator CastingDuration(Collider cast, float dur, bool vis) {

        yield return new WaitForSeconds(dur);
        cast.enabled = true;
        vis = true;
    }



}



    /*// Use this for initialization
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
                        intoExp.GetComponent<Health>().AreaHeal(10);
                    }
                }

            }




        }


        //redemption
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
                        intoExp.GetComponent<EnemyManager>().Slow(10);
                    }
                }

            }

        }

    }

    

    */
