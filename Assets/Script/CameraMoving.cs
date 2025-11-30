using Unity.Cinemachine;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public CinemachineCamera freeLook3D;

    // 2D용 FreeLook 카메라
    public CinemachineCamera freeLook2D;

    bool use3D = true;   // 현재 3D를 쓰는지 여부

    void Start()
    {
        // 시작할 때 기본으로 쓸 카메라 정하기 (원하는 쪽으로 바꿔도 됨)
        SetCamera(true);   // true = 3D 사용, false = 2D 사용
    }

    // 버튼에서 호출할 함수
    public void ToggleFreeLook()
    {
        use3D = !use3D;
        SetCamera(use3D);
    }

    void SetCamera(bool use3d)
    {
        use3D = use3d;

        if (use3D)
        {
            // 3D 카메라가 우선순위 높게
            freeLook3D.Priority = 20;
            freeLook2D.Priority = 10;
        }
        else
        {
            // 2D 카메라가 우선순위 높게
            freeLook3D.Priority = 10;
            freeLook2D.Priority = 20;
        }
    }
}
