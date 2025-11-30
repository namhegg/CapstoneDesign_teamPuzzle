using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{
    public GameObject gameover;
    public GameObject restart;
    public GameObject winTextObject;
    public GameObject Player;
    public GameObject Goal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.Player = GameObject.Find("Player");
        this.Goal = GameObject.Find("Finish");
    }

// Update is called once per frame
void Update()
    {
        Vector3 p = Player.transform.position;
        Vector3 g = Goal.transform.position;
        Vector3 dir = p - g;
        
        

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
