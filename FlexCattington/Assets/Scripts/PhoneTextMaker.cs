using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneTextMaker : MonoBehaviour
{
    // Line height = 16
    // starting height = 34
    // max width = 184
    // min width = 22
    // letter width = 8

    // max chars per line = 20 

    // starting x = 125
    // letter x = 4
    // min x = 48

    private Text t;
    private RectTransform r;
    public GameObject childText;
    public int right = 1;

	void Start ()
    {
        t = childText.GetComponent<Text>();
        r = gameObject.GetComponent<RectTransform>();

        r.sizeDelta = new Vector2(30, 34);

        CalculateSpaceNeeded("Sup y'all, here be some example text generation. Oh look, another sentence");
	}

    public void CalculateSpaceNeeded(string text)
    {
        // set text
        t.text = text;

        // calculate number of letters
        int characters = text.Length;

        // calculate width of text
        float width = characters * 8 * right + 22;
        float x = 125 - (characters * 4) * right;
        if (width > 184)
        {
            width = 184 * right;
            x = 48 * right;
        }

        // calculate height of text
        float height = ((characters / 20) * 16) + 34;
        float textHeight = t.cachedTextGenerator.GetPreferredHeight(text, t.GetGenerationSettings(new Vector2(width - 22, height - 18)));
        if ((height - 18) < textHeight)
            height = textHeight + 18;

        // set position and size
        r.localPosition = new Vector3(x, r.localPosition.y, r.localPosition.z);
        r.sizeDelta = new Vector2(width, height);
    }
}