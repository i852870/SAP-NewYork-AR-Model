using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_on_editor : MonoBehaviour {

    public move_path PathToFollow;

    public int CurrentWayPointID = 0;
    public float speed;
    private float reachDistance = 1.0f;
    public float rotationspeed = 2.5f;
    public string pathName;

    Vector3 last_position;
    Vector3 current_position;

	// Use this for initialization
	void Start () {
     //   PathToFollow = GameObject.Find (pathName).GetComponent<move_path>();
        last_position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);

        var rotation = Quaternion.LookRotation(PathToFollow.path_objs[CurrentWayPointID].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationspeed);

        if (distance <= reachDistance) {
            CurrentWayPointID++;
        }
        if (CurrentWayPointID >= PathToFollow.path_objs.Count) {
            CurrentWayPointID = 0;
        }
	}
}
