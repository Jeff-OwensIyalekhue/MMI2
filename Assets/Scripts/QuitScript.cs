using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QuitScript : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
