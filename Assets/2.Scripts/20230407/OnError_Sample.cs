using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class OnError_Sample : MonoBehaviour
{
    StringReactiveProperty input = new StringReactiveProperty("10");
    void Start()
    {
        input.Select(_ => int.Parse(_)).Subscribe(_ => { Debug.Log(_ + " was Changed to int"); },
                                                 ex => { Debug.Log(ex + " : Error!!"); });
        input.Value = "0";
        input.Value = "12340";
        input.Value = "568";
        input.Value = "ssss";
        input.Value = "69";
    }
}
/*//실행결과//
0 was Changed to int
12340 was Changed to int
568 was Changed to int
System.FortmatException: Input string was not in a correct format
//////////*/