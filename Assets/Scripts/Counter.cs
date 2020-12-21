using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{

  public int initialValue;
  public int minValue = 0;
  public int maxValue = 10;
  public int step = 1;

  public bool enableConfirm = false;

  int value;

  Text text;
  Animator textAnim;
  Button increment;
  Button decrement;
  GameObject confirm;
  void Awake()
  {
    text = gameObject.transform.Find("Text").GetComponent<Text>();
    textAnim = text.GetComponent<Animator>();
    increment = gameObject.transform.Find("IncrementButton").GetComponent<Button>();
    decrement = gameObject.transform.Find("DecrementButton").GetComponent<Button>();
    confirm = gameObject.transform.Find("ConfirmButton").gameObject;

    value = initialValue;
  }

  // Update is called once per frame
  void Update()
  {
    confirm.SetActive(enableConfirm);

    if (value <= minValue)
    {
      value = minValue;
      increment.interactable = true;
      decrement.interactable = false;
    }
    else if (value == maxValue)
    {
      value = maxValue;
      increment.interactable = false;
      decrement.interactable = true;
    }
    else
    {
      increment.interactable = true;
      decrement.interactable = true;
    }
    text.text = "" + value;

  }

  public void Increment()
  {
    value += step;
    textAnim.SetTrigger("Change");
  }

  public void Decrement()
  {
    value -= step;
    textAnim.SetTrigger("Change");
  }

  public void SetConfirm(bool toSet)
  {
    enableConfirm = toSet;
  }

  public int getValue()
  {
    return value;
  }
}
