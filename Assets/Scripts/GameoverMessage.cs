using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameoverMessage : MonoBehaviour
{

  public bool didWin;

  bool win;
  Text text;

  // Start is called before the first frame update
  void Start()
  {
    text = gameObject.transform.Find("Text").GetComponent<Text>();
  }

  // Update is called once per frame
  void Update()
  {
    win = didWin;

    if (win)
    {
      text.text = "Correct!\nYou win!";
    }
    else
    {
      text.text = "Wrong!\nYou lose!";
    }
  }
}
