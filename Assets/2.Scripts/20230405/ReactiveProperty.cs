using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ReactiveProperty : MonoBehaviour
{
    [SerializeField] IntReactiveProperty A = new IntReactiveProperty();      // �Ű����� = �ʱⰪ
    // int���� ReactivePropery // IntReactivePropertyó�� �� �ڷ������� �̸� ������ ���� ����ϸ� SerializeFieldȭ ����
    void Start()
    {
        A.Subscribe(x => { Debug.Log("A : " + x); });        // Subscribe �س����� �� ������ OnNext �߻� // Subscribe�� ���۵� ������ ���� OnNext�� ���޵�

        A.Value = 10;                               // .Value�� �� ���� ����
        A.Value = 20;

        var B = new ReactiveProperty<int>(0);       
        B.Value = 30;
        B.Subscribe(x => { Debug.Log("B : " + x); });
    }
}

/*///// ��� /////
A : 0
A : 10
A : 20
B : 30
///////////////*/