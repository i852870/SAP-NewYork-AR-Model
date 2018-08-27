using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_boat_X_axis : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = .025f;

    [SerializeField]
    private float distance = 3.0f;
    // Use this for initialization

    private float startingX;
    private bool isMoving = true;

    void Start()
    {
        startingX = transform.position.x;
        StartCoroutine (Float());

    }
    private IEnumerator Float()
    {
        while (true)
        {
            float newX = transform.position.x + (isMoving ? 1 : -1) * 4 * distance * moveSpeed * Time.deltaTime;

            if (newX > startingX + distance)
            {
                newX = startingX + distance;
                isMoving = false;
            }
            else if (newX < startingX)
            {
                newX = startingX;
                isMoving = true;
            }

            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            yield return 0;
        }
    }
}