using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float speed = 10f;
    public FixedJoystick joystick;
    public Transform rayOrigin;
    public Transform currentCube;

    Rigidbody rb;               // Rigidbody of the player.
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        RayCastDown();
    }

    // Update is called once per frame
    // void Update()
    // FixedUpdate is called once per fixed frame-rate frame.
    void FixedUpdate()      // 고정된 프레임 레이트로 함수를 콜하게(실행하게) 됨
    {                       // 일정 시간 간격으로 실행되기 때문에 delta.Time이 없어도 됨

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");



    }
    void Update()
    {
        RayCastDown();
        float moveVertical = joystick.Vertical;
        Vector3 movement = new Vector3(moveVertical, 0.0f, 0.0f); // Create a 3D movement vector using the inputs.
        transform.Translate(movement * speed * Time.deltaTime, Space.World);      // Apply force to the Rigidbody to move the player.



        if (animator != null)
        {
            float moveAmount = Mathf.Abs(moveVertical);
            Debug.Log($"moveVertical: {moveVertical}, moveAmount: {moveAmount}");
            animator.SetFloat("Speed", moveAmount);
        }
    }

    public void RayCastDown()
    {
        if (rayOrigin == null) return;   // 안전장치

        Ray playerRay = new Ray(
            transform.position + transform.TransformVector(.5f, 3f,0), // origin
            transform.TransformDirection(0.1f, -0.1f,0)                  // direction
        );

        //Debug.DrawLine(playerRay.origin, playerRay.origin + playerRay.direction * 0.8f, Color.red);

        RaycastHit playerHit;

        if (Physics.Raycast(playerRay, out playerHit))
        {
            if (playerHit.transform.gameObject.layer == LayerMask.NameToLayer("Road"))
            {
                currentCube = playerHit.transform;
            }
        }
    }
}