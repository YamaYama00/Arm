using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class Floor : MonoBehaviour {
    GameObject targetpos_object;
    TargetPos targetpos_script;

    GameObject targetpos2_object;
    TargetPos2 targetpos2_script;

    GameObject targetpos3_object;
    TargetPos3 targetpos3_script;

    GameObject root2_object;
    root2 root2_script;

    GameObject root1_object;
    root1 root1_script;

    GameObject goal_object;
    Goal goal_script;

    GameObject goal2_object;
    Goal2 goal2_script;

    GameObject goal3_object;
    Goal3 goal3_script;


    public bool work_state = false;
    public float y = 0;
    public bool floor_state = false;
    float floor_rot;
    public bool bring_state = false;
    public bool move1_state = false;
    public bool move2_state = false;
    int start_state = 0;

    public float target_pos_x;
    public float target_pos_y;
    public float target_pos_z;
    public float x_relative;
    public float y_relative;
    public float z_relative;
    public float r;
    public float x_goal_relative;
    public float y_goal_relative;
    public float z_goal_relative;
    public float r_goal;

    public float adjust;
    bool adjust_state;

    public int work_times = 0;

    public float velocity_x = 0.1f;
    public float velocity_z = 0.1f;
//Hanoi
    int hanoi_work_time = 0;
    char[] goal = new char[9];
    int[] target = new int[9];

    void Start() {
	targetpos_object = GameObject.Find("target");
	targetpos_script = targetpos_object.GetComponent<TargetPos>();
	targetpos2_object = GameObject.Find("target2");
	targetpos2_script = targetpos2_object.GetComponent<TargetPos2>();
	targetpos3_object = GameObject.Find("target3");
	targetpos3_script = targetpos3_object.GetComponent<TargetPos3>();
	root1_object = GameObject.Find("root1");
	root1_script = root1_object.GetComponent<root1>();
	root2_object = GameObject.Find("root2");
	root2_script = root2_object.GetComponent<root2>();
	goal_object = GameObject.Find("goal");
	goal_script = goal_object.GetComponent<Goal>();
	goal2_object = GameObject.Find("goal2");
	goal2_script = goal2_object.GetComponent<Goal2>();
	goal3_object = GameObject.Find("goal3");
	goal3_script = goal3_object.GetComponent<Goal3>();
	hanoi(3, 'A', 'B', 'C');
    }

    void hanoi(int n, char from, char work, char dest) {

	if (n >= 2) {
	    hanoi(n - 1, from, dest, work);
	}

	hanoi_work_time += 1;
	target[hanoi_work_time] = n - 1;
	goal[hanoi_work_time] = dest;
	if (n >= 2) {
	    hanoi(n - 1, work, from, dest);
	}
    }

    void Move1 () {

	Vector3 pos = transform.position;
	velocity_x = 0.2f * Mathf.Abs(x_relative) / Mathf.Sqrt(x_relative * x_relative + z_relative * z_relative);
	velocity_z = 0.2f * Mathf.Abs(z_relative) / Mathf.Sqrt(x_relative * x_relative + z_relative * z_relative);

	if (x_relative > 0) {
	    pos.x += velocity_x;
	}
	else if (x_relative < 0) {
	    pos.x -= velocity_x;
	}

	if (z_relative > 0) {
	    pos.z += velocity_z;
	}
	else if (z_relative < 0) {
	    pos.z -= velocity_z;
	}
	transform.position = pos;
    }

    void Move2 () {
	velocity_x = 0.2f * Mathf.Abs(x_goal_relative) / Mathf.Sqrt(x_goal_relative * x_goal_relative + z_goal_relative * z_goal_relative);
	velocity_z = 0.2f * Mathf.Abs(z_goal_relative) / Mathf.Sqrt(x_goal_relative * x_goal_relative + z_goal_relative * z_goal_relative);

	Vector3 pos = transform.position;
	if (x_goal_relative > 0) {
	    pos.x += velocity_x;
	}
	else if (x_goal_relative < 0) {
	    pos.x -= velocity_x;
	}

	if (z_goal_relative > 0) {
	    pos.z += velocity_z;
	}
	else if (z_goal_relative < 0) {
	    pos.z -= velocity_z;
	}
	transform.position = pos;
    }

    void Catch () {

	work_state = true;
	floor_rot = Mathf.Atan2(x_relative,
		z_relative) * Mathf.Rad2Deg;
	if (y - floor_rot < 180 && y - floor_rot > 0) {
	    y -= 1.5f;
	}
	else if (y - floor_rot > -360 && y - floor_rot <= -180) {
	    y -= 1.5f;
	}
	else if (y - floor_rot >= 360) {
	    y -= 1.5f;
	}
	else if (y - floor_rot <= -360){
	    y += 1.5f;
	}
	else if (y - floor_rot < 0 && y - floor_rot > -180) {
	    y += 1.5f;
	}
	else if (y - floor_rot < 360 && y - floor_rot >= 180) {
	    y += 1.5f;
	}
	else {
	    y += 1.5f;
	}
	if (Mathf.Abs(y - floor_rot) < 1) {
	    floor_state = true;
	}
	else if (Mathf.Abs(Mathf.Abs(y - floor_rot) - 360) < 1) {
	    floor_state = true;
	}
    }

    void Bring () {
	floor_rot = Mathf.Atan2(x_goal_relative,
		z_goal_relative) * Mathf.Rad2Deg;
	if (y - floor_rot < 180 && y - floor_rot > 0) {
	    y -= 1;
	}
	else if (y - floor_rot > -360 && y - floor_rot <= -180) {
	    y -= 1;
	}
	else if (y - floor_rot >= 360) {
	    y -= 1;
	}
	else if (y - floor_rot <= -360){
	    y += 1;
	}

	else if (y - floor_rot < 0 && y - floor_rot > -180) {
	    y += 1;
	}
	else if (y - floor_rot < 360 && y - floor_rot >= 180) {
	    y += 1;
	}
	else {
	    y += 1.5f;
	}

	print(bring_state);
	if (Mathf.Abs(y - floor_rot) < 1) {
	    bring_state = true;
	}
	else if (Mathf.Abs(Mathf.Abs(y - floor_rot) - 360) < 1) {
	    bring_state = true;
	}
    }

    void Height1 () {
	adjust = 0;
	if (target[work_times + 1] != 0 && Mathf.Abs(goal_script.pos_z - targetpos_script.pos_z) < 2f) {
	    adjust += 2.0f;
	}
	if (target[work_times + 1] != 1 && Mathf.Abs(goal_script.pos_z - targetpos2_script.pos_z) < 2f) {
	    adjust += 2.0f;
	}
	if (target[work_times + 1] != 2 && Mathf.Abs(goal_script.pos_z - targetpos3_script.pos_z) < 2f) {
	    adjust += 2.0f;
	}

    }

    void Height2 () {
	adjust = 0;
	if (target[work_times + 1] != 0 && Mathf.Abs(goal2_script.pos_z - targetpos_script.pos_z) < 2f) {
	    adjust += 2.0f;
	}
	if (target[work_times + 1] != 1 && Mathf.Abs(goal2_script.pos_z - targetpos2_script.pos_z) < 2f) {
	    adjust += 2.0f;
	}
	if (target[work_times + 1] != 2 && Mathf.Abs(goal2_script.pos_z - targetpos3_script.pos_z) < 2f) {
	    adjust += 2.0f;
	}

    }

    void Height3 () {
	adjust = 0;
	if (target[work_times + 1] != 0 && Mathf.Abs(goal3_script.pos_z - targetpos_script.pos_z) < 2f) {
	    adjust += 2.0f;
	}
	if (target[work_times + 1] != 1 && Mathf.Abs(goal3_script.pos_z - targetpos2_script.pos_z) < 2f) {
	    adjust += 2.0f;
	}
	if (target[work_times + 1] != 2 && Mathf.Abs(goal3_script.pos_z - targetpos3_script.pos_z) < 2f) {
	    adjust += 2.0f;
	}
    }

    void Update () {
/*
//make csv file
	Encoding enc = Encoding.GetEncoding("Shift_JIS");
	StreamWriter writer = new StreamWriter("./state2.csv", true, enc);
	writer.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", root1_script.catch_state, root2_script.catch_state, root2_script.fi, root1_script.theta, root1_script.x, root2_script.x);
	writer.Close();
*/
	transform.rotation = Quaternion.Euler(0, (int)y, 0);
//init

	if (target[work_times + 1] == 0) {
	    target_pos_x = targetpos_script.pos_x;
	    target_pos_y = targetpos_script.pos_y + 0f;
	    target_pos_z = targetpos_script.pos_z;
	}

	else if (target[work_times + 1] == 1) {
	    target_pos_x = targetpos2_script.pos_x;
	    target_pos_y = targetpos2_script.pos_y + 0.5f;
	    target_pos_z = targetpos2_script.pos_z;
	}

	else if (target[work_times + 1] == 2) {
	    target_pos_x = targetpos3_script.pos_x;
	    target_pos_y = targetpos3_script.pos_y - 2f;
	    target_pos_z = targetpos3_script.pos_z;
	}

	if (goal[work_times + 1] == 'A') {
	    Height1();
	    x_goal_relative = goal_script.pos_x - transform.position.x;
	    y_goal_relative = goal_script.pos_y - transform.position.y + adjust;
	    z_goal_relative = goal_script.pos_z - transform.position.z;
	}
	else if (goal[work_times + 1] == 'B') {
	    Height2();
	    x_goal_relative = goal2_script.pos_x - transform.position.x;
	    y_goal_relative = goal2_script.pos_y - transform.position.y + adjust;
	    z_goal_relative = goal2_script.pos_z - transform.position.z;
	}
	else if (goal[work_times + 1] == 'C') {
	    Height3();
	    x_goal_relative = goal3_script.pos_x - transform.position.x;
	    y_goal_relative = goal3_script.pos_y - transform.position.y + adjust;
	    z_goal_relative = goal3_script.pos_z - transform.position.z;

	}
	if (work_state == false) {
	    start_state = 0;
	    work_state = false;
	    floor_state = false;
	    bring_state = false;
	    move1_state = false;
	    move2_state = false;
	    root2_script.catch_state = false;
	    root2_script.put_state = false;
	    root2_script.pickup_state = false;
	    root1_script.catch_state = false;
	    root1_script.pickup_state = false;
	    root1_script.put_state = false;
	    if (work_times >= hanoi_work_time) {
		start_state += 2;
	    }
	}

	x_relative = target_pos_x - transform.position.x;
	y_relative = target_pos_y - transform.position.y;
	z_relative = target_pos_z - transform.position.z;
	/*
	x_goal_relative = goal_script.pos_x - transform.position.x;
	//y_goal_relative = goal_script.pos_y - transform.position.y;
	z_goal_relative = goal_script.pos_z - transform.position.z;
*/
	float r = Mathf.Sqrt(
		x_relative * x_relative +
		z_relative * z_relative
		);
	float r_goal = Mathf.Sqrt(
		x_goal_relative * x_goal_relative +
		z_goal_relative * z_goal_relative
		);

	//move1
	if (r > 13 && move1_state == false && floor_state == true) {
	    Move1();
	}
	if (r <= 13 && start_state == 0 && floor_state == true) {
	    move1_state = true;
	    start_state += 1;
	}

	//find and catch
	if (floor_state == false && root2_script.catch_state == false && start_state == 0) {
	    Catch();
	}
	//move2
	if (r_goal > 13 && move2_state == false && root1_script.pickup_state == true && bring_state == true) {
	    Move2();
	}
	else if (r_goal <= 13 && root1_script.pickup_state == true && bring_state == true) {
	    move2_state = true;
	}

	if (root1_script.pickup_state == true && bring_state == false) {
	    Bring();
	}
    }
}
