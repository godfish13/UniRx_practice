using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Subject_create : MonoBehaviour
{
    Subject<string> sub = new Subject<string>();

    WaitForSeconds ws = new WaitForSeconds(3f);

    void Start()
    {
        sub.Subscribe(_ => Debug.Log("sub1 : " + _));
        sub.Subscribe(_ => Debug.Log("sub2 : " + _));
        StartCoroutine(Praticer());
    }

    IEnumerator Praticer()
    {
        yield return ws;
        sub.OnNext("Hello, World!");
        yield return ws;
        sub.OnNext("Bye, World!");
    }
}
