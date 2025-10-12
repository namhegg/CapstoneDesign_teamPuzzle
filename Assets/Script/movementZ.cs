using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movementz : MonoBehaviour
{
    Transform tf;
    Vector3 startPos;
    Vector3 rstartPos;
    Vector3 deltaPos;
    bool clicked;

    private void Awake()
    {
        tf = transform;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        startPos = Camera.main.WorldToScreenPoint(transform.position);
        rstartPos = startPos - Input.mousePosition;
        deltaPos.z = startPos.z - rstartPos.z;
    }

    private void OnMouseDrag()
    {
        deltaPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + rstartPos);
        tf.position = new Vector3(tf.position.x, tf.position.y, deltaPos.z);
        // TODO. -17.5f 범위만 바꿔
        if (-17.5f > deltaPos.z)
        {
            // TODO. -17.5f 범위만 바꿔
            tf.position = new Vector3(tf.position.x, tf.position.y, 17.5f);
        }
        // TODO. 0.5f 범위만 바꿔
        else if (0.5f < deltaPos.z) 
        {
            // TODO. 0.5f 범위만 바꿔
            tf.position = new Vector3(tf.position.x, tf.position.y, 0.5f);
        }

    }

    private void OnMouseUp()
    {
        clicked = false;
    }
}
