using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider : MonoBehaviour {
    public static float sld_x1;
    public static float sld_y1;
    public static float sld_x2;
    public static float sld_y2;
    public static float sld_x3;
    public static float sld_y3;

    Slider slider_x1;
    Slider slider_y1;
    Slider slider_x2;
    Slider slider_y2;
    Slider slider_x3;
    Slider slider_y3;

// Use this for initialization
    void Start () {
	slider_x1 = GameObject.Find("Slider_x1").GetComponent<Slider>();
	slider_y1 = GameObject.Find("Slider_y1").GetComponent<Slider>();
	slider_x2 = GameObject.Find("Slider_x2").GetComponent<Slider>();
	slider_y2 = GameObject.Find("Slider_y2").GetComponent<Slider>();
	slider_x3 = GameObject.Find("Slider_x3").GetComponent<Slider>();
	slider_y3 = GameObject.Find("Slider_y3").GetComponent<Slider>();
    }

// Update is called once per frame
    void Update () {
	sld_x1 = slider_x1.value;
	sld_y1 = slider_y1.value;
	sld_x2 = slider_x2.value;
	sld_y2 = slider_y2.value;
	sld_x3 = slider_x3.value;
	sld_y3 = slider_y3.value;
    }
}
