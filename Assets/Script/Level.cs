using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Level :MonoBehaviour
{
    public void OnClickGotoSelect()
    {
        SceneManager.LoadScene("LevelScene");
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
