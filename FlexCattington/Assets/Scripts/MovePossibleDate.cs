using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePossibleDate : MonoBehaviour {
    //Moving the Waldo dates
    // Use this for initialization

    //Int that decides which direction they move\
    public int moveInt;
    //vector that convers prefab location to screenpoint
    private Vector3 screenPoint;
    //the transforms x value
    private float xPos;
	void Start ()
    {
        xPos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (moveInt == 1)
            xPos -= 0.1f;
        else if (moveInt == 2)
            xPos += 0.1f;
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPoint.x < 0 || screenPoint.x > 1)
        {
            xPos = -xPos;
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
            
    }
}
