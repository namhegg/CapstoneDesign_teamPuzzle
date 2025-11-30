using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class rotationX : MonoBehaviour
{
    [Header("x 회전 범위")]
    public float minX = 0.0f;
    public float maxX = 0.0f;

    Transform tf;
    Vector3 startPos;
    Vector3 rstartPos;
    Vector3 deltaPos;
    Vector3 rotation;
    bool clicked;
    float rotationSpeed = 5.0f;

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
        rotation.x = (deltaPos.x + deltaPos.y) * Time.deltaTime * rotationSpeed; 
        tf.Rotate(rotation);
        
         // TODO. -17.5f 범위만 바꿔
        if (minX > transform.rotation.x)
        {
            // TODO. -17.5f 범위만 바꿔
            tf.rotation = Quaternion.identity;
        }
        // TODO.  0.5f 범위만 바꿔
        else if (maxX < transform.rotation.x)
        {
            // TODO. 0.5f 범위만 바꿔
            tf.rotation = Quaternion.identity;
        }

    }

    private void OnMouseUp()
    {
        clicked = false;
    }
}
