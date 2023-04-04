using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Timer_event : MonoBehaviour
{
    public delegate void eventTimer(int time);      // delegate ����
    public event eventTimer eventHandler;           // eventHandler �ۼ�

    void Start() => StartCoroutine(Timer());
    
    private WaitForSeconds ws = new WaitForSeconds(1);
    IEnumerator Timer()           // ���� eventHanlder�� �ð� ����
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
