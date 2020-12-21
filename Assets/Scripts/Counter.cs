using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{

    public int initialValue;
    public int minValue = 0;
    public int maxValue = 10;
    public int step = 1;

    public bool enableConfirm = false;

    int value;

    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    Animator textAnim;
    [SerializeField]
    Button increment;
    [SerializeField]
    Button decrement;
    [SerializeField]
    GameObject confirm;

    void Awake()
    {
        if (text == null)
        {
            text = gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        }
        if (textAnim == null)
        {
            textAnim = text.GetComponent<Animator>();
        }
        if (increment == null)
        {
            increment = gameObject.transform.Find("IncrementButton").GetComponent<Button>(); 
        }
        if (decrement == null)
        {
            decrement = gameObject.transform.Find("DecrementButton").GetComponent<Button>(); 
        }
        if (confirm == null)
        {
            confirm = gameObject.transform.Find("ConfirmButton").gameObject; 
        }

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
        text.SetText(value.ToString());

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
