using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
public class ClickMove : MonoBehaviour 
{
    NavMeshAgent agent;

    public LayerMask layerMask; // Layer Road 감지용
    public bool isRoad = false; // 길이 있는지 확인용
    public GameObject CuronRoad; // 현재 큐브 위인지

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();   //agent로 컴포넌트 받기

        layerMask = LayerMask.GetMask("Road");  //Road만 설정
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))    //화면 클릭을 통한 agent의 목적지 설정
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        Ray rayRoad1 = new Ray(             //새로운 ray 설정, 길의 유무를 확인하는 ray, 정면 대각선 아랫방향으로 향해 cude를 탐지
            transform.position + transform.TransformVector(0, -1.2f, .5f),  // 오브젝트의 앞에서 나오도록 하기
            transform.TransformDirection(0, 0.1f, -0.2f)                    // 오브젝트의 아랫대각방향으로 나와 바닥 탐지
        );
        Debug.DrawLine(rayRoad1.origin, rayRoad1.origin + rayRoad1.direction * 0.8f, Color.red); //개발 편의성을 위한 ray 표시

        if(Physics.Raycast(rayRoad1, out RaycastHit hitCiff) == false)      // ray를 통해 길이 없는 지 확인
        {
            isRoad = true;
        }

        if (isRoad == true)
        {
            agent.SetDestination(CuronRoad.transform.position);         //길이 없으면 그 전 큐브로 후퇴
            isRoad = false;
        }
        else if (!Physics.Raycast(rayRoad1, out _, 0.8f, layerMask))
        {
            isRoad = true;                  // 감지 거리 내에 길이 없으면 막다른 길로 판단
        }

        Ray rayRoad2 = new Ray(             //새로운 ray 설정, 어떤 길 위에 있는 지 확인(CuronRoad)하는 ray
            transform.position,
            transform.TransformDirection(0, -1, 0)
        );
        // Debug.DrawLine(rayRoad2.origin, rayRoad2.origin + rayRoad2.direction * 0.8f, Color.blue); 개발 편의성을 위한 ray 표시

        if (Physics.Raycast(rayRoad2, out RaycastHit hitRoad))  // ray의 충돌이 있는 지 확인 후 실행 >> player가 서 있는 cube의 정보를 CuronRoad에 저장
        {
            if (hitRoad.transform.tag.Contains("Road"))
            {
                CuronRoad = hitRoad.transform.gameObject;
            }
        }

    }
}
