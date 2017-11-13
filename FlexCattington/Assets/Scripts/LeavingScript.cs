using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-5, 0));
    }
}
