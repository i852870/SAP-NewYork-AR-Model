using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_editor_boat : MonoBehaviour
{

    //path we need to get to 
    public move_path_boat PathToFollow;

    
    public int CurrentWayPointID = 0;
    public float speed;
    private float reachDistance = 1.0f; //smaller this is urglier the movement 
    public float rotationspeed = 2.5f;
    public string pathName; //name of the path

    Vector3 last_position;
    Vector3 current_position;

    // Use this for initialization
    void Start()
    {
        //last position, so we have an actual position
        last_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //creating distance between points, point we are starting at: waypointId and transform position we are at
        float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
        //setting up our current position
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);


        if (distance <= reachDistance)
        {
            CurrentWayPointID++;
        }
        if (CurrentWayPointID >= PathToFollow.path_objs.Count)
        {
            CurrentWayPointID = 0;
        }
    }
}
