using UnityEngine;

public class textcontroll : MonoBehaviour
{
    public GameObject textObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            textObject.SetActive(false);
        }
    }
}
