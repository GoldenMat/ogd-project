using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        GameObject go = PhotonNetwork.Instantiate("Player Model", new Vector3(Random.Range(0f, 20f), 0f, Random.Range(0f, 20f)), Quaternion.identity, 0);
        if(go.GetComponent<PhotonView>().isMine)
        {
            go.GetComponent<MovementGhost>().enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
