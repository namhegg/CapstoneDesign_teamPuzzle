using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{
    public GameObject gameover;
    public GameObject restart;
    public GameObject winTextObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

// Update is called once per frame
void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            Time.timeScale = 0;
            winTextObject.SetActive(true);
    }
    public void OnclickQuit()
    {
        SceneManager.LoadScene("LevelScene");
    }
    public void OnclickRestart()
    {
        SceneManager.LoadScene("Stage1-1");
    }
}
