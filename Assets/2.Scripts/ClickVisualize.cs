using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using TMPro;

namespace UniRxPracitce
{
    public class ClickVisualize : MonoBehaviour
    {
        [SerializeField] private Button btn;    // [SerializeField]�� �����صθ� private������ inspecterâ���� ���� ����
        [SerializeField] private TextMeshProUGUI txt;
        
        void Start()
        {
            btn.onClick.AsObservable().Subscribe(input =>
            {
                txt.text = "Clicked";
            });   
        }
    }
}

