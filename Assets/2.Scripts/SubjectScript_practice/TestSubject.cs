using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TestSubject : MonoBehaviour
{
    public Subject<int> mySubject = new Subject<int>();

    IEnumerator Start()
    {
        var wait = new WaitForSeconds(1f);

        yield return wait;
        mySubject.OnNext(1);
        yield return wait;
        mySubject.OnNext(2);
        yield return wait;
        mySubject.OnNext(3);
        mySubject.OnCompleted();
    }
}
