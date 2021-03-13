using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public int roundLength = 60;

    public int initialValue;
    public int minValue = 0;
    public int maxValue = 25;
    public int step = 1;

    int value;

    [SerializeField]
    TextMeshProUGUI counterText;
    [SerializeField]
    Animator textAnim;
    [SerializeField]
    Button increment;
    [SerializeField]
    Button decrement;
    [SerializeField]
    Button confirm;
    [SerializeField]
    TextMeshProUGUI timerText;

    float initTime;
    bool isFinished = false;

    void Awake()
    {
        if (counterText == null)
        {
            counterText = gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        }
        if (textAnim == null)
        {
            textAnim = counterText.GetComponent<Animator>();
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
            confirm = gameObject.transform.Find("ConfirmButton").GetComponent<Button>();
        }
        if (counterText == null)
        {
            confirm.GetComponentInChildren<TextMeshProUGUI>();
        }

        value = initialValue;
    }

    private void Start()
    {
        initTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
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

        if (!isFinished)
            Round();
    }

    public void Round()
    {
        float t = roundLength - (Time.time - initTime);
        if (t > 0)
        {
            counterText.SetText(value.ToString());
            timerText.SetText(t.ToString("N0"));
        }
        else if (t <= 0)
        {
            timerText.SetText("confirm");
            isFinished = true;
        }
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

    public void SetConfirm()
    {
        GameoverMessage.didWin = value == BallsInstantiation.amountBalls;
    }

    public int getValue()
    {
        return value;
    }
}
