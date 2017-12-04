using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaiterScript : MonoBehaviour {

    public bool correctCoffee;
    public float score;
    public GameObject wrong;
    public GameObject right;
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
        score = PlayerPrefs.GetFloat("score");
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
        if (!correctCoffee && gameObject.transform.position.x < -1.7)
            StartCoroutine(ShowUnhappyFlex(wrong.transform.position));
        else if (correctCoffee && gameObject.transform.position.x < -1.7)
            StartCoroutine(ShowHappyFlex(right.transform.position));
        if (gameObject.transform.position.x < -13)
        {
            CoffeeScore();
            PlayerPrefs.SetFloat("score", score);
            SceneManager.LoadScene("Conversation");
        }
    }

    public void CoffeeScore()
    {
        if (!correctCoffee)
            score -= 10;
        else
            score += 15;

    }

    IEnumerator ShowHappyFlex(Vector3 start)
    {
        for (float time = 0; time < 0.5f; time += Time.deltaTime)
        {
            right.transform.position = Vector3.Lerp(start, new Vector3(3.63f, -3.0f, -2.6f), time / 0.5f);
            yield return null;
        }
    }

    IEnumerator ShowUnhappyFlex(Vector3 start)
    {
        for (float time = 0; time < 0.5f; time += Time.deltaTime)
        {
            wrong.transform.position = Vector3.Lerp(start, new Vector3(3.63f, -3.0f, -2.6f), time / 0.5f);
            yield return null;
        }
    }
}
