using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeSetter : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<WaiterScript>().correctCoffee = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
