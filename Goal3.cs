using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal3 : MonoBehaviour {
    public float pos_x;
    public float pos_y;
    public float pos_z;
/*
    Slider slider_x3;
    Slider slider_y3;
*/
    void Start () {
/*	slider_x3 = GameObject.Find("Slider_x3").GetComponent<Slider>();
	slider_y3 = GameObject.Find("Slider_y3").GetComponent<Slider>();
*/    }
    void Update () {
	Vector3 pos = transform.position;
	pos.x = slider.sld_x3;
	pos.z = slider.sld_y3;
	transform.position = pos;
	pos_x = transform.position.x;
	pos_y = transform.position.y;
	pos_z = transform.position.z;
    }
}
