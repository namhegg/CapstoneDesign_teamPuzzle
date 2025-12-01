using UnityEngine;

public class rotationZ : MonoBehaviour
{
    [Header("z 회전 제한 범위")]
    public float minZ = 0.0f;
    public float maxZ = 0.0f;

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

    private void OnMouseDown()
    {
        startPos = Camera.main.WorldToScreenPoint(transform.position);
        rstartPos = startPos - Input.mousePosition;
        deltaPos.z = startPos.z - rstartPos.z;
    }

    private void OnMouseDrag()
    {
        deltaPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + rstartPos);
        rotation.z = (deltaPos.z + deltaPos.y) * Time.deltaTime * rotationSpeed;
        tf.Rotate(rotation);


        if (minZ > transform.rotation.z)
        {

            tf.rotation = Quaternion.identity;
        }
 
        else if (maxZ < transform.rotation.z)
        {

            tf.rotation = Quaternion.identity;
        }

    }

    private void OnMouseUp()
    {
        clicked = false;
    }
}
