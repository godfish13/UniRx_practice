using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class UniRx_Coroutine : MonoBehaviour
{
    void Start()
    {
        Observable.FromCoroutine<int>(observer => GamerTimer(observer, 60)).Subscribe(t => Debug.Log(t));
    }

    IEnumerator GamerTimer(IObserver<int> observer, int initialCount)
    {
        int Count = initialCount;
        while(Count > 0)
        {
            observer.OnNext(Count--);

            yield return new WaitForSeconds(1);
        }
        observer.OnCompleted();
    }
}
/*//// 실행결과 ////
60
59
58
...
1
///////////////////*/