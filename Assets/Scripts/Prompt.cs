using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Prompt : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    public string ballToFind = null;

    // Start is called before the first frame update
    void Awake()
    {
        if (text == null)
        {
            text = gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ballToFind != null)
        {
            gameObject.SetActive(true);
            text.text = "How many " + ballToFind + "s?";
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void setBallToFind(string ball)
    {
        ballToFind = ball;
    }
}
