using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameoverMessage : MonoBehaviour
{

    public static bool didWin;

    bool win;
    [SerializeField]
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        if (text == null)
            text = gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>();
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
