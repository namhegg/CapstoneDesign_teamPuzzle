using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Collections;

public class dotween : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            StartCoroutine(ExampleCoroutine());

            transform.DORotate(new Vector3(0, 180, 0), 3);
            IEnumerator ExampleCoroutine()
            {
                yield return new WaitForSeconds(3);
                SceneManager.LoadScene("test2");
            }
        }
    }
}
