using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prompt : MonoBehaviour
{

  Text text;
  public string ballToFind = null;

  // Start is called before the first frame update
  void Awake()
  {
    text = gameObject.transform.Find("Text").GetComponent<Text>();
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
