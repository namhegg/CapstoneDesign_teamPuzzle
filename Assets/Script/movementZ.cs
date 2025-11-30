using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movementz : MonoBehaviour
{
    [Header("z 이동 제한 범위")]
    public float minZ = 0.0f;
    public float maxZ = 0.0f;

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
        if (minZ > deltaPos.z)
        {
            // TODO. -17.5f 범위만 바꿔
            tf.position = new Vector3(tf.position.x, tf.position.y, minZ);
        }
        // TODO. 0.5f 범위만 바꿔
        else if (maxZ < deltaPos.z) 
        {
            // TODO. 0.5f 범위만 바꿔
            tf.position = new Vector3(tf.position.x, tf.position.y, maxZ);
        }
    }

    private void OnMouseUp()
    {
        clicked = false;
    }
}
