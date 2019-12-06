using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug_scr : MonoBehaviour {
    public GameObject Debug_object = null;
    GameObject Floor_object;
    Floor Floor_script;
    GameObject root1_object;
    root1 root1_script;
    GameObject root2_object;
    root2 root2_script;
    GameObject cube_object;
    cube cube_script;


    float i;
    void Start() {
	Floor_object = GameObject.Find("floor1");
	Floor_script = Floor_object.GetComponent<Floor>();
	root1_object = GameObject.Find("root1");
	root1_script = root1_object.GetComponent<root1>();
	root2_object = GameObject.Find("root2");
	root2_script = root2_object.GetComponent<root2>();
	cube_object = GameObject.Find("Cube");
	cube_script = cube_object.GetComponent<cube>();

    }

    void Update() {
	i = Mathf.Abs((int)Floor_script.y);
	Text debug_text = Debug_object.GetComponent<Text>();
	debug_text.text = i.ToString();
    }
}
