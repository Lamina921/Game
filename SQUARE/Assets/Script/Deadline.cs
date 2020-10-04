
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadline : MonoBehaviour
{
    public static Deadline instance;
    public static Rigidbody2D body;
    private static int shakeTime=10;
    private static float shakeAmount = 0.1f;
    public delegate void DeadlineWork(Collider2D collision);
    public static DeadlineWork DestroyMethod;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2.right*5;
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            DestroyMethod(collision);
    }
    public static  void Shake_it(Collider2D collision)
    {
       instance.StartCoroutine(Shake_itIE(collision.GetComponent<Transform>(), (int)collision.GetComponent<SpriteRenderer>().size.x* shakeTime));
    }
    public static IEnumerator Shake_itIE(Transform trans,int length) {
        
        Vector3 rotationAmount,origin_position= trans.position;
        while (length > 0)
        {
            if(!Control.isPause)
            {
                --length;
                rotationAmount = UnityEngine.Random.insideUnitCircle * shakeAmount;
                rotationAmount.z = 0;
                trans.localPosition = trans.position + rotationAmount;
            }
            yield return null;
        }
        trans.gameObject.AddComponent<Rigidbody2D>();//let it drop
        instance.StartCoroutine(Wait_to_DestroyIE(trans.gameObject, 60));
    }
    public static IEnumerator Wait_to_DestroyIE(GameObject gameObject,int length)
    {
        while (length > 0)
        {
            if (!Control.isPause)
            {
                --length;
            }
            yield return null;
        }
        Destroy(gameObject);
    }

}
