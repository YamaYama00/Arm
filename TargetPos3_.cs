using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TargetPos3_ : MonoBehaviour {
    GameObject root2_object;
    root2 root2_script;
    GameObject root1_object;
    root1 root1_script;
    GameObject Floor_object;
    Floor Floor_script;

    public float pos_x;
    public float pos_y;
    public float pos_z;

    void Start(){
	root2_object = GameObject.Find("root2");
	root2_script = root2_object.GetComponent<root2>();
	root1_object = GameObject.Find("root1");
	root1_script = root1_object.GetComponent<root1>();
	Floor_object = GameObject.Find("floor1");
	Floor_script = Floor_object.GetComponent<Floor>();

	pos_x = transform.position.x;
	pos_y = transform.position.y;
	pos_z = transform.position.z;
    }
    void Update(){
	Vector3 pos = transform.position;
	pos.x = slider.sld_x1;
	pos.z = slider.sld_y1;
	transform.position = pos;

	if (Floor_script.work_times == 3) {
	    if (Floor_script.work_state == true && root2_script.catch_state == true && root1_script.catch_state == true){
		this.GetComponent<RotationConstraint>().enabled = true;
		this.GetComponent<PositionConstraint>().enabled = true;

//		transform.parent = GameObject.Find("Cube").transform
;
	    }
	    if (root2_script.catch_state == false || (root2_script.put_state == true && root1_script.put_state == true)){
		this.GetComponent<RotationConstraint>().enabled = false;
		this.GetComponent<PositionConstraint>().enabled = false;
		//transform.parent = null;
	    }
	}
	pos_x = transform.position.x;
	pos_y = transform.position.y;
	pos_z = transform.position.z;
    }
}
