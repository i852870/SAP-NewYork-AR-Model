using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_path : MonoBehaviour {

    //color for our path, so that we can actively see it
    public Color rayColor = Color.white;

    //public list of type tranforms that stores every transform
    public List<Transform> path_objs = new List<Transform> ();
    //array pof type transforms
    Transform[] theArray;


    //we dont need start and update so we deleted it

        //this function allows you to draw path and see it in the editor
     void OnDrawGizmos()
    {
        //set color to white that we already set up
        Gizmos.color = rayColor;
        //now we want to get transform type children components of our main object in the list
        theArray = GetComponentsInChildren<Transform> ();
        //then we want to clear this at the start up
        path_objs.Clear();

        //no here we go through each and every children object path_obj in our main array
        foreach (Transform path_obj in theArray) {
            //if path_obj children does not have the same properties as the main object(so we dont use that parent object)
            if (path_obj != this.transform) {
                //then add that object to the path_onj list
                path_objs.Add(path_obj);

            }
        }

        //now we count all the passed objects in our list and then postition those objects using vectors

        for (int i = 0; i < path_objs.Count; i++) {
            Vector3 position = path_objs[i].position;
            //checking is we have something in our list
            if (i > 0) {

                //we create a previous object 
                Vector3 previous = path_objs[i - 1].position;

                //we draw a line from our previous position to the current position
                Gizmos.DrawLine(previous, position);
                //draw a sphere on that position point
                Gizmos.DrawWireSphere(position, 0.3f);

            }
        }

    }
}
