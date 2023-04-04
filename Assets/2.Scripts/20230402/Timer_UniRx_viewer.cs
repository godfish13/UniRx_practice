using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class Timer_UniRx_viewer : MonoBehaviour
{
    [SerializeField] private Timer_UniRx timerRx;
    [SerializeField] private Text timeText;

    void Start()
    {
        timerRx.OnTimeChanged.Subscribe((x) =>  // observable�� OnTimeChanged�� Subscribe�Ͽ� timerSubject�� OnNext ����
        { 
            timeText.text = x.ToString();
        });
    }
}
