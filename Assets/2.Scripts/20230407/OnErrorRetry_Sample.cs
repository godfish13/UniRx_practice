using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class OnErrorRetry_Sample : MonoBehaviour
{
    StringReactiveProperty input = new StringReactiveProperty("10");
    void Start()
    {
        input.Select(_ => int.Parse(_)).OnErrorRetry((FormatException ex) => { Debug.Log("Format Exception Errupted"); })
                                       .Subscribe(_ => { Debug.Log(_ + " was Changed to int"); },
                                                  ex => { Debug.Log(ex + " : Error!!"); });
        input.Value = "0";
        input.Value = "12340";
        input.Value = "568";
        input.Value = "ssss";
        input.Value = "69";
    }
}
/*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
�� �ڵ�� ������ �ȵǰ� ���ѷ������·� ����. Retryó���� ������ ������ ������ ������� ����.*/