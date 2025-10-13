using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void OnClickSelectLevel()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
