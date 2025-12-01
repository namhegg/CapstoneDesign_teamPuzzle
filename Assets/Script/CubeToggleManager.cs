using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CubeToggleManager : MonoBehaviour
{
    [Header("전환할 큐브들")]
    public List<SetonCube> cubes = new List<SetonCube>();

    // UI 버튼에서 이 함수를 호출
    public void ToggleAllCubes()
    {
        foreach (SetonCube cube in cubes)
        {
            if (cube != null)
            {
                cube.onClickButton();
            }
        }
    }
}
