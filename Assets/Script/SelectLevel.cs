using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SelectLevel : MonoBehaviour
{
    public void OnClickLevel1_1()
    {
        SceneManager.LoadScene("Stage1-1");
    }

    public void OnClickLevel1_2()
    {
        SceneManager.LoadScene("1-2");
    }

    public void OnClickLevel1_3()
    {
        SceneManager.LoadScene("1-3");
    }

    public void OnClickQuit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                        Application.Quit();
        #endif
    }
}
