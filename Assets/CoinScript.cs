using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
    [SerializeField]
    private float floatSpeed = 0.25f; // cycles up and down
                                     // Use this for initialization
    [SerializeField]
    private float movementDistance = 0.25f;

    private float StartingY;
    private bool isMoving = true;

	void Start () {
        StartingY = transform.position.y;
        StartCoroutine(Float());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator Float()
    {
        while (true)
        {
            float newY = transform.position.y + (isMoving ? 1 : -1) * 2 * movementDistance * floatSpeed * Time.deltaTime;

            if (newY > StartingY + movementDistance)
            {
                newY = StartingY + movementDistance;
                isMoving = false;
            }
            else if (newY < StartingY)
            {
                newY = StartingY;
                isMoving = true;
            }

            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            yield return 0;
        }
    }
}
