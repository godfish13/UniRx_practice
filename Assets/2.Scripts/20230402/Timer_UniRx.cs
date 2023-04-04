using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Timer_UniRx : MonoBehaviour
{
    private Subject<int> timerSubject = new Subject<int>();     // �̺�Ʈ �����ϴ� �ٽ� �ν��Ͻ�!
    public IObservable<int> OnTimeChanged => timerSubject;      // �̺�Ʈ�� �����ڿ��� timerSubject�� observable�ϰ� ����
                                                                // => : get Ű���� ����(�б�����Ӽ�)
                                                                // == public IObservable<int> OnTimeChanged { get { return timerSubject; } }
    void Start() => StartCoroutine(Timer());

    private WaitForSeconds ws = new WaitForSeconds(1);
    private IEnumerator Timer()
    {
        int time = 1;
        while (time < 30)
        {
            timerSubject.OnNext(time);      // 1�ʸ��� timerSubject�� 1�� ����
            time++;
            yield return ws;
        }
    }
}
