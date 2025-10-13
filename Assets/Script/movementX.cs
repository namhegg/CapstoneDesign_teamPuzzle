using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Unity.AI.Navigation;

public class movementX : MonoBehaviour
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
        deltaPos.x = startPos.x - rstartPos.x;
    }

    private void OnMouseDrag()
    {
        deltaPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + rstartPos);
        tf.position = new Vector3(deltaPos.x, tf.position.y, tf.position.z);
        // TODO. -17.5f 범위만 바꿔
        if (-17.5f > deltaPos.x)
        {
            // TODO. -17.5f 범위만 바꿔
            tf.position = new Vector3(-17.5f, tf.position.y, tf.position.z);
        }
        // TODO.  0.5f 범위만 바꿔
        else if (0.5f < deltaPos.x)
        {
            // TODO. 0.5f 범위만 바꿔
            tf.position = new Vector3(0.5f, tf.position.y, tf.position.z);
        }
    }

    private void OnMouseUp()
    {
        clicked = false;
    }
}
