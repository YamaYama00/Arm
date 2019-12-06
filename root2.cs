using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class root2 : MonoBehaviour {
    GameObject targetpos_object;
    TargetPos targetpos_script;

    GameObject root1_object;
    root1 root1_script;

    GameObject Floor_object;
    Floor Floor_script;

    GameObject Goal_object;
    Goal Goal_script;

    public bool catch_state = false;
    public bool put_state = false;
    public bool pickup_state = false;

    public float x = 60;
    public float fi;
    float eps = 4;
    float length_arm1 = 8;
    float length_arm2 = 8;
    float r;

    void Start () {
	targetpos_object = GameObject.Find("target");
	targetpos_script = targetpos_object.GetComponent<TargetPos>();
	root1_object = GameObject.Find("root1");
	root1_script = root1_object.GetComponent<root1>();
	Goal_object = GameObject.Find("goal");
	Goal_script = Goal_object.GetComponent<Goal>();
	Floor_object = GameObject.Find("floor1");
	Floor_script = Floor_object.GetComponent<Floor>();

    }

    void Catch () {
	float r = root1_script.r;

	//deno_part1 is temporary variable
	float deno_part1 = (root1_script.r * root1_script.r
		+ (Floor_script.target_pos_y + eps) * (Floor_script.target_pos_y + eps)
		- length_arm1 * length_arm1
		+ length_arm2 * length_arm2)
		/ (2 * length_arm2);

	float beta = Mathf.Acos((r * r
		+ (Floor_script.target_pos_y + eps) * (Floor_script.target_pos_y + eps)
		- length_arm1 * length_arm1
		- length_arm2 * length_arm2)
		/ (2 * length_arm1 * length_arm2)
		);

	float A = Mathf.Sqrt(deno_part1 * deno_part1
		+ length_arm1 * length_arm1 * Mathf.Sin(beta) * Mathf.Sin(beta));

	float lambda = Mathf.Atan2(2 * length_arm1 * length_arm2 * Mathf.Sin(beta),
		r * r
		+ (Floor_script.target_pos_y + eps) * (Floor_script.target_pos_y + eps)
		+ length_arm2 * length_arm2
		- length_arm1 * length_arm1
		);

	fi = Mathf.Asin(r / A) * Mathf.Rad2Deg - lambda * Mathf.Rad2Deg;

	float theta = root1_script.theta;

	if (root1_script.floor_state) {
	    if (x - theta <= -0.5) {
		x += 0.5f;
	    }
	    else if (x - theta > 0.5) {
		x -= 0.5f;
	    }
	}
/*
	if (Mathf.Abs(x - theta) < 0.5f && Mathf.Abs(root1_script.x - fi) < 0.5f) {
	    catch_state = true;
	}
*/
    }

    void Pickup() {
	if (x > 90) {
	    x -= 0.5f;
	}
	else if (x <= 90) {
	    x += 0.5f;
	}
	if (Mathf.Abs(x - 90) < 5f) {
	    pickup_state = true;
	}
    }

    void Put () {
	float r = root1_script.r;

	//deno_part1 is temporary variable
	float deno_part1 = (root1_script.r * root1_script.r
		+ (Goal_script.pos_y + eps) * (Goal_script.pos_y + eps)
		- length_arm1 * length_arm1
		+ length_arm2 * length_arm2)
		/ (2 * length_arm2);

	float beta = Mathf.Acos((r * r
		+ (Goal_script.pos_y + eps) * (Goal_script.pos_y + eps)
		- length_arm1 * length_arm1
		- length_arm2 * length_arm2)
		/ (2 * length_arm1 * length_arm2)
		);

	float A = Mathf.Sqrt(deno_part1 * deno_part1
		+ length_arm1 * length_arm1 * Mathf.Sin(beta) * Mathf.Sin(beta));

	float lambda = Mathf.Atan2(2 * length_arm1 * length_arm2 * Mathf.Sin(beta),
		r * r
		+ (Goal_script.pos_y + eps) * (Goal_script.pos_y + eps)
		+ length_arm2 * length_arm2
		- length_arm1 * length_arm1
		);

	fi = Mathf.Asin(r / A) * Mathf.Rad2Deg - lambda * Mathf.Rad2Deg;
	float theta = root1_script.theta;

	if (x - theta <= -0.5) {
	    x += 0.5f;
	}
	else if (x - theta > 0.5) {
	    x -= 0.5f;
	}

	if (Mathf.Abs(x - theta) < 0.5 && Mathf.Abs(root1_script.x - fi) < 0.5f) {
	    put_state = true;
	}
    }

    void Update () {
	transform.rotation = Quaternion.Euler((int)x, 0, 0);
	if (Floor_script.work_state == false) {
	    catch_state = false;
	    put_state = false;
	    pickup_state = false;
	}

	//find and catch
	if (catch_state == false && Floor_script.floor_state == true && Floor_script.move1_state == true) {
	    Catch();
	}
	if (Mathf.Abs(x - root1_script.theta) < 0.5f && Mathf.Abs(root1_script.x - fi) < 0.5f) {
	    catch_state = true;
	}
	if (root1_script.catch_state ==true && catch_state == true && pickup_state ==false) {
	    Pickup();
	}
	if (Floor_script.bring_state == true && put_state == false
		&& pickup_state == true && root1_script.pickup_state == true&& Floor_script.move2_state == true) {
	    Put();
	}
    }
}
