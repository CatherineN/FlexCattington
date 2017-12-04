using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waldo : MonoBehaviour
{

    // Use this for initialization
    //Keep track of score
    public float score;
    int counter;
    GameObject wrong;
	void Start ()
    {
        wrong = GameObject.Find("WrongAnswer");
        //wrong.SetActive(false);
        score = PlayerPrefs.GetFloat("score");
        //Decrease score for every second the player spends on the screen
        StartCoroutine("DecreaseScore");
        counter = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        //Debug.Log(lifeCounter);
		if(Input.GetMouseButtonUp (0))
        {
            // don't analyze clicks when the title card is up
            if (GameObject.Find("WaldoTitleCard") != null)
                return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            Debug.Log(hit.transform);
            if (hit.transform.tag == "Incorrect")
            {
                hit.transform.tag = "Not Wrapping";
                score -= 5;
                StartCoroutine(ShowFlex(wrong.transform.position));

            }
            else if (hit.transform.tag == "Correct")
            {
                SceneManager.LoadScene("CafeInterior");
                PlayerPrefs.SetFloat("score", score);
            }
                

        }
        /*if (counter >= 1)
            counter++;
        if(counter==20)
        {
            counter = 0;
            wrong.SetActive(false);
        }*/
	}
    IEnumerator DecreaseScore()
    {
        score -= 0.1f;
        yield return new WaitForSeconds(1);
        StartCoroutine("DecreaseScore");
    }

    IEnumerator ShowFlex(Vector3 start)
    {
        for(float time = 0; time < 0.5f; time += Time.deltaTime)
        {
            wrong.transform.position = Vector3.Lerp(start, new Vector3(3.63f, -2.0f, -2.6f), time / 0.5f);
            yield return null;
        }

        yield return new WaitForSeconds(1.25f);

        for (float time = 0; time < 0.5f; time += Time.deltaTime)
        {
            wrong.transform.position = Vector3.Lerp(new Vector3(3.63f, -2.0f, -2.6f), start, time / 0.5f);
            yield return null;
        }
    }
}
