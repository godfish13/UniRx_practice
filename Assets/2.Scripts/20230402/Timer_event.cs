using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Timer_event : MonoBehaviour
{
    public delegate void eventTimer(int time);      // delegate 선언
    public event eventTimer eventHandler;           // eventHandler 작성

    void Start() => StartCoroutine(Timer());
    
    private WaitForSeconds ws = new WaitForSeconds(1);
    IEnumerator Timer()           // 매초 eventHanlder에 시간 전달
    {
        int time = 1;
        while (time < 30)
        {
            eventHandler(time);
            time++;
            yield return ws;
        }
    }
}
