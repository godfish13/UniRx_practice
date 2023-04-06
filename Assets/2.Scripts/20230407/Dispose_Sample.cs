using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Dispose_Sample : MonoBehaviour
{
    void Start()
    {
        Subject<string> subject = new Subject<string>();

        //IDispose�� ���� == �� ��Ʈ���� ���� ������ �� �ִ�.
        IDisposable Stream1 = subject.Subscribe(x => Debug.Log("Stream1 : " + x), () => Debug.Log("Stream1 OnCompleted"));
        IDisposable Stream2 = subject.Subscribe(x => Debug.Log("Stream2 : " + x), () => Debug.Log("Stream2 OnCompleted"));
        subject.OnNext("A");
        subject.OnNext("B");

        //Stream1 �� Subscribe ����
        Stream1.Dispose();

        subject.OnNext("C");
        subject.OnCompleted();
    }
}
/*//������//
Stream1 : A
Stream2 : A
Stream1 : B
Stream2 : B
Stream2 : C
Stream2 OnCompleted
//////////*/