using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waldo : MonoBehaviour
{

    // Use this for initialization
    //Keep track of score
    public int score = 1000;
	void Start ()
    {
        //Decrease score for every second the player spends on the screen
        StartCoroutine("DecreaseScore");
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
                hit.transform.tag = "Not Wrapping";
                score -= 20;
            }
            else if (hit.transform.tag == "Correct")
                SceneManager.LoadScene("CafeInterior");

        }
	}
    IEnumerator DecreaseScore()
    {
        score -= 1;
        yield return new WaitForSeconds(1);
        StartCoroutine("DecreaseScore");
    }
}
