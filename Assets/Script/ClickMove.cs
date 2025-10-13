using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
public class ClickMove : MonoBehaviour 
{
    NavMeshAgent agent;

    public LayerMask layerMask; // Layer Road ������
    public bool isRoad = false; // ���� �ִ��� Ȯ�ο�
    public GameObject CuronRoad; // ���� ť�� ������

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();   //agent�� ������Ʈ �ޱ�

        layerMask = LayerMask.GetMask("Road");  //Road�� ����
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))    //ȭ�� Ŭ���� ���� agent�� ������ ����
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        Ray rayRoad1 = new Ray(             //���ο� ray ����, ���� ������ Ȯ���ϴ� ray, ���� �밢�� �Ʒ��������� ���� cude�� Ž��
            transform.position + transform.TransformVector(0, -1.2f, .5f),  // ������Ʈ�� �տ��� �������� �ϱ�
            transform.TransformDirection(0, 0.1f, -0.2f)                    // ������Ʈ�� �Ʒ��밢�������� ���� �ٴ� Ž��
        );
        // Debug.DrawLine(rayRoad1.origin, rayRoad1.origin + rayRoad1.direction * 0.8f, Color.red); ���� ���Ǽ��� ���� ray ǥ��

        if(Physics.Raycast(rayRoad1, out RaycastHit hitCiff) == false)      // ray�� ���� ���� ���� �� Ȯ��
        {
            isRoad = true;
        }

        if (isRoad == true)
        {
            agent.SetDestination(CuronRoad.transform.position);         //���� ������ �� �� ť��� ����
            isRoad = false;
        }
        else if (!Physics.Raycast(rayRoad1, out _, 0.8f, layerMask))
        {
            isRoad = true;                  // ���� �Ÿ� ���� ���� ������ ���ٸ� ��� �Ǵ�
        }

        Ray rayRoad2 = new Ray(             //���ο� ray ����, � �� ���� �ִ� �� Ȯ��(CuronRoad)�ϴ� ray
            transform.position,
            transform.TransformDirection(0, -1, 0)
        );
        // Debug.DrawLine(rayRoad2.origin, rayRoad2.origin + rayRoad2.direction * 0.8f, Color.blue); ���� ���Ǽ��� ���� ray ǥ��

        if (Physics.Raycast(rayRoad2, out RaycastHit hitRoad))  // ray�� �浹�� �ִ� �� Ȯ�� �� ���� >> player�� �� �ִ� cube�� ������ CuronRoad�� ����
        {
            if (hitRoad.transform.tag.Contains("Road"))
            {
                CuronRoad = hitRoad.transform.gameObject;
            }
        }

    }
}
