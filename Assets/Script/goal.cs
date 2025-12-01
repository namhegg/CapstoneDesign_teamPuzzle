using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class goal : MonoBehaviour
{
    public VisualEffect finishVFX;   // 인스펙터에서 vfxgraph_finish 드래그

    public GameObject clearUI;       // 클리어 UI가 있으면 연결 (없으면 비워둬도 OK)

    bool isCleared = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isCleared) return;                
        if (!other.CompareTag("Player")) return;

        isCleared = true;
        Debug.Log("클리어!");
        finishVFX.Play();

        if (clearUI != null)
        {
            Debug.LogWarning("clearUI!!!");
            clearUI.SetActive(true);
        }
        else
        {
            Debug.LogWarning("clearUI가 Inspector에 할당되어 있지 않음!");
        }
    }
    public void OnclickQuit()
    {
        SceneManager.LoadScene("LevelScene");
    }
    public void OnclickRestart()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void OnclickRestart1()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void OnClickPause()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
