using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ReactiveProperty : MonoBehaviour
{
    [SerializeField] IntReactiveProperty A = new IntReactiveProperty();      // 매개변수 = 초기값
    // int형의 ReactivePropery // IntReactiveProperty처럼 각 자료형으로 미리 구현된 것을 사용하면 SerializeField화 가능
    void Start()
    {
        A.Subscribe(x => { Debug.Log("A : " + x); });        // Subscribe 해놓으면 값 수정시 OnNext 발생 // Subscribe가 시작된 순간의 값도 OnNext로 전달됨

        A.Value = 10;                               // .Value로 값 변경 가능
        A.Value = 20;

        var B = new ReactiveProperty<int>(0);       
        B.Value = 30;
        B.Subscribe(x => { Debug.Log("B : " + x); });
    }
}

/*///// 결과 /////
A : 0
A : 10
A : 20
B : 30
///////////////*/