using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBS : MonoBehaviour {

    bool growing = false;
    public Camera cam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!growing )
        {
            growing = false;
            cam.orthographicSize -= .1f;
            if(cam.orthographicSize < .2)
            {
                growing = true;
            }
        }
        if(growing)
        { 
            if(cam.orthographicSize > 5.2)
            {
                growing = false;
            }
            cam.orthographicSize += .1f;
        }
	}
}
