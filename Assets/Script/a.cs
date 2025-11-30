using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;
public class a : MonoBehaviour
{
    public LayerMask layermask;
    public bool isRoad = false;

    public GameObject CurrentRoad;
    public Transform currentCube;
    public Transform clickCube;
    public Transform indicator;

    public List<Transform> finalPath = new List<Transform>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RayCastDown();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCube)
        {

        }
    }
    public void RayCastDown()
    {

        Ray playerRay = new Ray(transform.GetChild(0).position, -transform.up);
        RaycastHit playerHit;

        if (Physics.Raycast(playerRay, out playerHit))
        {
            if (playerHit.transform.GetComponent<Road>() != null)
            {
                currentCube = playerHit.transform;
            }
        }
    }
}
