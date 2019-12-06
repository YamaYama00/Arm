using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal2 : MonoBehaviour {
    public float pos_x;
    public float pos_y;
    public float pos_z;

/*    Slider slider_x2;
    Slider slider_y2;
*/
    void Start () {
/*	slider_x2 = GameObject.Find("Slider_x2").GetComponent<Slider>();
	slider_y2 = GameObject.Find("Slider_y2").GetComponent<Slider>();
*/    }
    void Update () {
	Vector3 pos = transform.position;
	pos.x = slider.sld_x2;
	pos.z = slider.sld_y2;
	transform.position = pos;
	pos_x = transform.position.x;
	pos_y = transform.position.y;
	pos_z = transform.position.z;

    }
}
