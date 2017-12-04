using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaiterScript : MonoBehaviour {

    public bool correctCoffee;
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
        correctCoffee = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (leaving)
        {
            Leave();
        }
        CheckForTransition();
		
	}
    void Leave()
    {
        gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-5, 0));
        
    }
    void CheckForTransition()
    {
        if (gameObject.transform.position.x < -13)
        {
            SceneManager.LoadScene("Conversation");
        }
    }

    public void CoffeeScore()
    {

    }
}
