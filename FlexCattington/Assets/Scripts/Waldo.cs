using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waldo : MonoBehaviour
{

    // Use this for initialization
    //List to keep track of the life Icons
    public List<GameObject> lifeIcons = new List<GameObject>();
    //Counter to keep track of lifeicons
    private int lifeCounter = 0;
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(lifeCounter);
		if(Input.GetMouseButtonUp (0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
                Debug.Log("hi");
            if (hit.transform.tag == "Incorrect")
            {
                lifeIcons[lifeCounter].gameObject.SetActive(false);
                lifeCounter++;
            }
            else if (hit.transform.tag == "Correct")
                SceneManager.LoadScene("CafeInterior");

        }
	}
}
