using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class root1 : MonoBehaviour {
    GameObject targetpos_object;
    TargetPos targetpos_script;

    GameObject targetpos2_object;
    TargetPos2 targetpos2_script;

    GameObject root2_object;
    root2 root2_script;

    GameObject Floor_object;
    Floor Floor_script;

    GameObject Goal_object;
    Goal Goal_script;

    GameObject cube_object;
    cube cube_script;

    float eps = 4;
    float length_arm1 = 8;
    float length_arm2 = 8;
    public float r;

    public float x = 0;
    public float theta;
    public bool floor_state;
    public bool pickup_state = false;
    public bool put_state = false;
    public bool catch_state = false;
    //for initialization
    void Start () {
	targetpos_object = GameObject.Find("target");
	targetpos_script = targetpos_object.GetComponent<TargetPos>();
	targetpos2_object = GameObject.Find("target2");
	targetpos2_script = targetpos2_object.GetComponent<TargetPos2>();
	root2_object = GameObject.Find("root2");
	root2_script = root2_object.GetComponent<root2>();
	Floor_object = GameObject.Find("floor1");
	Floor_script = Floor_object.GetComponent<Floor>();
	Goal_object = GameObject.Find("goal");
	Goal_script = Goal_object.GetComponent<Goal>();
	cube_object = GameObject.Find("Cube");
	cube_script = cube_object.GetComponent<cube>();
	x = 10;
    }

    void Catch () {

	r = Mathf.Sqrt(Floor_script.x_relative * Floor_script.x_relative
	    + Floor_script.z_relative * Floor_script.z_relative);
	float fi = root2_script.fi;

	floor_state = Floor_script.floor_state;

	theta = fi + Mathf.Acos((
		r * r
		+ (targetpos_script.pos_y + eps) * (targetpos_script.pos_y + eps)
		- length_arm1 * length_arm1
		- length_arm2 * length_arm2
		)
		/ (2 * length_arm1 * length_arm2)
		) * Mathf.Rad2Deg;

	if (floor_state) {
	    if (x - fi < -0.5) {
		x += 0.5f;
	    }

	    else if (x - fi > 0.5) {
		x -= 0.5f;
	    }
	    if (Mathf.Abs(x - fi) < 0.5f) {
		catch_state = true;
	    }
	}
    }

    void Pickup () {
	if (x > 0) {
	    x -= 0.5f;
	}
	else if (x <= 0) {
	    x += 0.5f;
	}
	if (Mathf.Abs(x) < 0.4f) {
	    if (pickup_state == true) {
		Floor_script.work_state = false;
		Floor_script.work_times += 1;
	    }
	    pickup_state = !pickup_state;
	}
    }

    void Put () {
	r = Mathf.Sqrt(Floor_script.x_goal_relative * Floor_script.x_goal_relative
	    + Floor_script.z_goal_relative * Floor_script.z_goal_relative);
	float fi = root2_script.fi;

	floor_state = Floor_script.floor_state;

	theta = fi + Mathf.Acos((
		r * r
		+ (Floor_script.y_goal_relative + eps) * (Floor_script.y_goal_relative + eps)
		- length_arm1 * length_arm1
		- length_arm2 * length_arm2
		)
		/ (2 * length_arm1 * length_arm2)
		) * Mathf.Rad2Deg;

	if (x - fi < -0.5) {
	    x += 0.5f;
	}

	else if (x - fi > 0.5) {
	    x -= 0.5f;
	}

	if (Mathf.Abs(x - fi) < 0.5f && Mathf.Abs(root2_script.x - theta) < 0.5f) {
	    put_state = true;
	}
    }

    void Update () {
	transform.rotation = Quaternion.Euler((int)x, 0, 0);

	if (Floor_script.work_state == false) {
	    pickup_state = false;
	    put_state = false;
	    catch_state = false;
	}
	//find and catch
	if (catch_state == false && Floor_script.floor_state == true && Floor_script.move1_state == true) {
	    Catch();
	}
	//pick up
	if (catch_state == true && root2_script.catch_state == true && pickup_state == false) {
	    Pickup();
	}
	//put
	if (Floor_script.bring_state == true && put_state == false && Floor_script.move2_state == true) {
	    Put();
	}
	if (pickup_state == true && put_state == true && root2_script.put_state == true) {
	    Pickup();
	}

    }
}
