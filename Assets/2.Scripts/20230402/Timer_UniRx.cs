using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Timer_UniRx : MonoBehaviour
{
    private Subject<int> timerSubject = new Subject<int>();     // 이벤트 발행하는 핵심 인스턴스!
    public IObservable<int> OnTimeChanged => timerSubject;      // 이벤트의 구독자에게 timerSubject를 observable하게 해줌
                                                                // => : get 키워드 생략(읽기전용속성)
                                                                // == public IObservable<int> OnTimeChanged { get { return timerSubject; } }
    void Start() => StartCoroutine(Timer());

    private WaitForSeconds ws = new WaitForSeconds(1);
    private IEnumerator Timer()
    {
        int time = 1;
        while (time < 30)
        {
            timerSubject.OnNext(time);      // 1초마다 timerSubject가 1씩 발행
            time++;
            yield return ws;
        }
    }
}
