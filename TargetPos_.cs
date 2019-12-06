using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TargetPos_ : MonoBehaviour {
    GameObject root2_object;
    root2 root2_script;
    GameObject root1_object;
    root1 root1_script;
    GameObject Floor_object;
    Floor Floor_script;
    GameObject cube_object;
    cube cube_script;
    GameObject goal_object;
    Goal goal_script;
    GameObject goal2_object;
    Goal2 goal2_script;
    GameObject goal3_object;
    Goal3 goal3_script;

    public float pos_x;
    public float pos_y;
    public float pos_z;
    float x_goal;
    float y_goal;
    float z_goal;

    void Start () {
        root2_object = GameObject.Find("root2");
        root2_script = root2_object.GetComponent<root2>();
        root1_object = GameObject.Find("root1");
        root1_script = root1_object.GetComponent<root1>();
        Floor_object = GameObject.Find("floor1");
        Floor_script = Floor_object.GetComponent<Floor>();
        cube_object = GameObject.Find("Cube");
        cube_script = cube_object.GetComponent<cube>();
        goal_object = GameObject.Find("goal");
        goal_script = goal_object.GetComponent<Goal>();
        goal2_object = GameObject.Find("goal2");
        goal2_script = goal2_object.GetComponent<Goal2>();
        goal3_object = GameObject.Find("goal3");
        goal3_script = goal3_object.GetComponent<Goal3>();
           }

    void Update () {
        Vector3 pos = transform.position;
        pos.x = goal_script.pos_x;
        pos.z = goal_script.pos_z;
        transform.position = pos;
        print(goal_script.pos_x);
        pos_x = transform.position.x;
        pos_y = transform.position.y;
        pos_z = transform.position.z;
        if (Floor_script.work_times == 0 || Floor_script.work_times == 2 || Floor_script.work_times == 4 || Floor_script.work_times == 6){
            //if (Mathf.Abs(cube_script.pos_y - pos_y) < 5f) {
                this.GetComponent<RotationConstraint>().enabled = true;
                this.GetComponent<PositionConstraint>().enabled = true;

//            transform.parent = GameObject.Find("Cube").transform;
            //}
            if (
                root2_script.catch_state == false ||
                (root2_script.put_state == true &&
                 root1_script.put_state == true)) {

                this.GetComponent<RotationConstraint>().enabled = false;
            this.GetComponent<PositionConstraint>().enabled = false;
                //transform.parent = null;
            }
        }
    }
}
