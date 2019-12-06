using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour {
    public float pos_x;
    public float pos_y;
    public float pos_z;

    void Start () {
	pos_x = transform.position.x;
	pos_y = transform.position.y;
	pos_z = transform.position.z;
    }
    void Update () {
	pos_x = transform.position.x;
	pos_y = transform.position.y;
	pos_z = transform.position.z;
    }
}
