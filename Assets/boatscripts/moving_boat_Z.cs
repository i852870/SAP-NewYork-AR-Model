using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_boat_Z : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = .025f;

    [SerializeField]
    private float distance = 3.0f;
    // Use this for initialization

    private float startingZ;
    private bool isMoving = true;

    void Start()
    {
        startingZ = transform.position.z;
        StartCoroutine(Float());

    }
    private IEnumerator Float()
    {
        while (true)
        {
            float newZ = transform.position.z + (isMoving ? 1 : -1) * 4 * distance * moveSpeed * Time.deltaTime;

            if (newZ > startingZ + distance)
            {
                newZ = startingZ + distance;
                isMoving = false;
            }
            else if (newZ < startingZ)
            {
                newZ = startingZ;
                isMoving = true;
            }

            transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
            yield return 0;
        }
    }
}