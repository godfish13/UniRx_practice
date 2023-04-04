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
        timerRx.OnTimeChanged.Subscribe((x) =>  // observable한 OnTimeChanged를 Subscribe하여 timerSubject의 OnNext 감지
        { 
            timeText.text = x.ToString();
        });
    }
}
