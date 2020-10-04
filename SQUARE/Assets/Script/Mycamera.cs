using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mycamera : MonoBehaviour
{
    Transform _trans;
    public Transform target;
    static float offsetx=-2, offsety=1;
    static Vector3 v = new Vector3(0, 0, -5);
    // Start is called before the first frame update
    void Start()
    {
        _trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            v.x = target.position.x + offsetx;
            v.y = target.position.y + offsety;
            _trans.position = v;
        }
    }
    void ChangeOffset(float x,float y)
    {

    }
    public IEnumerator ChangeOffsetIE(float x, float y,int i)
    {
        while (i > 0)
        {
            i--;
            offsetx = Mathf.Lerp(offsetx, x, 0.5f);
            offsety = Mathf.Lerp(offsety, y, 0.5f);
            yield return null;
        }

    }
}
