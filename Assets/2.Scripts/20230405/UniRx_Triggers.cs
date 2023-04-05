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
/*////실행결과///		매 프레임마다 Update라고 콘솔에 표시함
Update
Update
…
/////////////////*/