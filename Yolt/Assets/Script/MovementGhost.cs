using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGhost : MonoBehaviour
{
    public float speed;
    public float smoothedSpeed;
    private float m_horizontal, m_vertical;
    private PhotonView myPhotonView;


    // Update is called once per frame
    void Update()
    {

        // ---------------

        //per evitare movimenti indesiderati, prendo solo il WASD ---> replace with switch case (?)
        /*
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(vec_up * speed * Time.deltaTime * Input.GetAxis("Vertical"), Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(vec_left * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(vec_down * speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(vec_rigth * speed * Time.deltaTime, Space.World);
        }
        */
        m_horizontal = Input.GetAxis("Horizontal");
        m_vertical = Input.GetAxis("Vertical");

        if (m_vertical != 0)
        {
            smoothedSpeed = speed;
            if (m_horizontal != 0)
            {
                smoothedSpeed = speed * 0.7f;
            }
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(m_vertical, 0f, m_vertical), smoothedSpeed * Time.deltaTime);

        }
        if (m_horizontal != 0)
        {
            smoothedSpeed = speed;
            if (m_vertical != 0)
            {
                smoothedSpeed = speed * 0.7f;
            }
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(m_horizontal, 0f, -m_horizontal), smoothedSpeed * Time.deltaTime);
        }
    }
}

