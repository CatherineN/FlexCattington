using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterScript : MonoBehaviour {

    public enum States
    {
        waiterApproach,
        questionPopped,
        possession,
        aftermath,
    }
    private Transform waiterTrans;
    private States gameState;
    
    private bool leaving = false;
	// Use this for initialization
	void Start () {
        waiterTrans = gameObject.transform;
        gameState = States.waiterApproach;
	}
	
	// Update is called once per frame
	void Update () {
        if (leaving)
        {
            Leave();
        }
		
	}
    void Leave()
    {
        gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-5, 0));
        
    }
}
