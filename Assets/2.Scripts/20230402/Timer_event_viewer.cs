using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_event_viewer : MonoBehaviour
{
    [SerializeField] private Text timeText;
    [SerializeField] private Timer_event timer_Event;

    // Start is called before the first frame update
    void Start()
    {
        timer_Event.eventHandler += (time) =>           // eventHandler에 시간표시 람다식 결합
        {
            timeText.text = time.ToString();
        };
    }
}
