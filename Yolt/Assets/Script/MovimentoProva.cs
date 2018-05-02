using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoProva : MonoBehaviour {

    public Transform player;
    public float height;
    public float smooth = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void update()
    {
        Vector3 pos = new Vector3();
        pos.x = player.position.x;
        pos.z = player.position.z - 7f;
        pos.y = player.position.y + height;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
    }

}
