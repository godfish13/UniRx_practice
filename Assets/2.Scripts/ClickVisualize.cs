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
        [SerializeField] private Button btn;    // [SerializeField]�� �����صθ� private������ inspecterâ���� ���� ����
        [SerializeField] private TextMeshProUGUI txt;   // TextMeshProUGUI�� ��� TextMeshPro���� ���� ���� ����(text�� legacy�� �Ǿ����� ������ �̰� �Ẹ��)

        [SerializeField] private int mode;  // 0 : change text if clicked, 1 : change text if clicked 3 times

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
            else if(mode == 1)
            {
                btn.OnClickAsObservable().Buffer(3).Subscribe(input =>
                {
                    txt.text = "Clicked";
                });
            }

            //btn.OnClickAsObservable().SubscribeToText(txt, input => "Clicked");       // unirx���� ��ó�� uGUI�� Observe�� Subscribe�� �غ�Ǿ� ����
                                                        //��, ���� ��ũ��Ʈ������ txt�� TextMeshProUGUI�� �����صξ����Ƿ� ���Ұ�, legacy�� text��� �� ����
        }
    }
}

