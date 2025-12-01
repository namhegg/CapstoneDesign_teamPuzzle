using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetonCube : MonoBehaviour
{
    [Header("원래의 z 좌표")]
    public float originZ = 0.0f;
    public bool is2d = false;

    public void onClickButton()
    {
        Vector3 pos = transform.position;

        if(is2d == true)
        {
            // 큐브의 z좌표를 0으로 이동시킴
            pos.z = originZ;
            transform.position = pos;

            is2d = false;// is2d를 false로 변환
        }
        else // 3d인 경우
        {
            // 큐브의 좌표를 originZ에 저장되어있던 좌표를 이동시킴
            originZ = pos.z;
            pos.z = 0f;
            transform.position = pos;

            is2d = true;// is2d를 true로 전환
        }
    }
}
