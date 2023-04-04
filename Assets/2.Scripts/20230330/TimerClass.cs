using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UsualWay
{
    public class TimerClass : MonoBehaviour
    {
        public delegate void TimerEventHandler(int time);   // �̺�Ʈ �ڵ鷯
        public event TimerEventHandler TimeUp;          // �̺�Ʈ �ڵ鷯�� ���� �̺�Ʈ

        WaitForSeconds ws = new WaitForSeconds(1);

        void Start()
        {
            StartCoroutine(TimeCouroutine());
        }

        IEnumerator TimeCouroutine()
        {
            int time = 1;
            while(time < 100)
            {
                TimeUp(time);
                time++;

                yield return ws;
            }
        }
    }
}
