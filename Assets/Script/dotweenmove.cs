using DG.Tweening;
using UnityEngine;

public class dotweenmove : MonoBehaviour
{
    public float speed;
    private Animator animt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animt = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            transform.DOMove(transform.position + transform.forward * speed * Time.deltaTime, 5);
            animt.Play("Walk");
        }
    }
}
