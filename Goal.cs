using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

    public float pos_x;
    public float pos_y;
    public float pos_z;
/*
    Slider slider_x1;
    Slider slider_y1;
*/
    void Start () {
/*	slider_x1 = GameObject.Find("Slider_x1").GetComponent<Slider>();
	slider_y1 = GameObject.Find("Slider_y1").GetComponent<Slider>();
*/    }
    void Update () {
	Vector3 pos = transform.position;
	pos.x = slider.sld_x1;
	pos.z = slider.sld_y1;
	transform.position = pos;
	pos_x = transform.position.x;
	pos_y = transform.position.y;
	pos_z = transform.position.z;
    }
}
