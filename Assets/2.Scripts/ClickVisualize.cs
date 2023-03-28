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
        [SerializeField] private Button btn;    // [SerializeField]를 선언해두면 private변수를 inspecter창에서 접근 가능
        [SerializeField] private TextMeshProUGUI txt;   // TextMeshProUGUI를 써야 TextMeshPro관련 내용 조작 가능(text는 legacy가 되었으니 가능한 이걸 써보자)
        
        void Start()
        {
            btn.onClick.AsObservable().Subscribe(input =>
            {
                txt.text = "Clicked";
            });   
        }
    }
}

