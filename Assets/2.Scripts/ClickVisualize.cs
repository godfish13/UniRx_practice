using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using TMPro;
using System;

namespace UniRxPracitce
{
    public class ClickVisualize : MonoBehaviour
    {
        [SerializeField] private Button btn;    // [SerializeField]를 선언해두면 private변수를 inspecter창에서 접근 가능
        [SerializeField] private TextMeshProUGUI txt;   // TextMeshProUGUI를 써야 TextMeshPro관련 내용 조작 가능(text는 legacy가 되었으니 가능한 이걸 써보자)

        [SerializeField] private int mode;  // 0 : change text if clicked, 1 : change text if clicked 3 times(use buffer), 2 : change text if clicked 3 times(use skip)

        void Start()
        {
            btn.OnClickAsObservable().Subscribe(input =>
            {
                Debug.Log("Clicked!");
            });

            if (mode == 0)
            {
                btn.onClick.AsObservable().Subscribe(input =>
                {
                    txt.text = "Clicked";
                });
            }
            else if(mode == 1)          // Buffer(n) : 메세지를 n횟수만큼 모아서 송신
            {
                btn.OnClickAsObservable().Buffer(3).Subscribe(input =>
                {
                    txt.text = "Clicked";
                });
            }
            else if (mode == 2)         // Skip(n) : 메세지를 n횟수만큼 무시하고 이후 송신
            {
                btn.OnClickAsObservable().Skip(2).Subscribe(input =>
                {
                    txt.text = "Clicked";
                });
            }

            //btn.OnClickAsObservable().SubscribeToText(txt, input => "Clicked");       // unirx에는 이처럼 uGUI용 Observe와 Subscribe가 준비되어 있음
            //단, SubscribeToText는 현재 스크립트에서는 txt를 TextMeshProUGUI로 설정해두었으므로 사용불가, legacy의 text사용 시 사용가능하다.
        }
    }
}