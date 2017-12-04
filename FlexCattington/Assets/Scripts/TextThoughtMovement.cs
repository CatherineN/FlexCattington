using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextThoughtMovement : MonoBehaviour
{
    // bounds
    // X = 400
    // Y = 300

    public float duration;
    private GameObject manager;

    private float timer;
    private CanvasGroup image; // acess to the color of the sprite
    private Vector3 target;
    private Vector3 start;
    private RectTransform r;
    public bool offscreen = false;

    // Use this for initialization
    void Start ()
    {
        image = gameObject.GetComponent<CanvasGroup>();
        r = gameObject.GetComponent<RectTransform>();
        manager = GameObject.Find("ScrollParent");
        FindNewPosition();
        FindNewTarget();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(offscreen)
        {
            r.localPosition = new Vector3(10000f, 0, 0);
            return;
        }
        if (timer >= duration)
        {
            timer = 0.0f;
            FindNewPosition();
            FindNewTarget();
        }
            

        if (timer <= 4)
            image.alpha = timer / 2;
        else
            image.alpha = 1 - ((timer - 4) / 2);

        float timeMapped = timer / duration;
        r.localPosition = Vector3.Lerp(start, target, timeMapped);

        timer += Time.deltaTime;

        
	}

    void FindNewPosition()
    {
        r.localPosition = new Vector3(Random.Range(-400, 400), Random.Range(-300, 300), 0);
        start = r.localPosition;
    }

    void FindNewTarget()
    {
        target = new Vector3(Random.Range(-400, 400), Random.Range(-300, 300), 0);
    }

    public void SetTime(float time)
    {
        timer = time;
    }

    public void OnMouseEnter()
    {
        gameObject.GetComponent<Outline>().enabled = true;
    }

    public void OnMouseExit()
    {
        gameObject.GetComponent<Outline>().enabled = false; ;
    }

    public void OnMouseDown()
    {
        PlayerPrefs.SetFloat("score", PlayerPrefs.GetFloat("score") + GetComponent<TextOption>().relationshipEffect);
        manager.GetComponent<TextMessageManager>().AddMessage(GetComponent<TextOption>().text);
        GameObject[] thoughts = GameObject.FindGameObjectsWithTag("Thought");
        for (int i = 0; i < thoughts.Length; i++)
        {
            thoughts[i].GetComponent<TextThoughtMovement>().offscreen = true;
        }

        StartCoroutine(manager.GetComponent<TextMessageManager>().Typing(GetComponent<TextOption>()));
        
    }
}
