using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class OnCompleted_Sample : MonoBehaviour
{
    void Start()
    {
        var input = new Subject<string>();
        input.Select(_ => int.Parse(_)).Subscribe(_ => { Debug.Log(_ + " was Changed to int"); },
                                                 ex => { Debug.Log(ex + " : Error!!"); },
                                                 () => { Debug.Log("OnCompleted!"); });
        input.OnNext("84");
        input.OnNext("74");
        input.OnNext("69");
        input.OnCompleted();
        input.OnNext("52");
    }
}
/*//실행결과//
84 was Changed to int
74 was Changed to int
69 was Changed to int
OnCompleted!
//////////*/