using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class UniRx_Triggers : MonoBehaviour
{
    void Start()
    {
        this.UpdateAsObservable().Subscribe(_ => { Debug.Log("Update"); });
    }
}
/*////������///		�� �����Ӹ��� Update��� �ֿܼ� ǥ����
Update
Update
��
/////////////////*/