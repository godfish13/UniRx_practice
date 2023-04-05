using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using TMPro;

namespace UniRxPracitce
{
    public class Click2buttons : MonoBehaviour
    {
        [SerializeField] private Button btn1;
        [SerializeField] private Button btn2;
        [SerializeField] private Text txt;       
        
        void Start()
        {
            btn1.OnClickAsObservable().Subscribe(_ => { Debug.Log("Botton1 Clicked!"); });
            btn2.OnClickAsObservable().Subscribe(_ => { Debug.Log("Botton2 Clicked!"); });
 
            btn1.OnClickAsObservable().Zip(btn2.OnClickAsObservable(),(b1,b2) => "Clicked!").First().Repeat().SubscribeToText(txt, input => txt.text + input + "\n");
        }
    }
}