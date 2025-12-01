using UnityEngine;
using UnityEngine.VFX;

public class SetoffObject : MonoBehaviour
{
    public GameObject targetObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }
}
