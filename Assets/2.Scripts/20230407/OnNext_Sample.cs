using System.Collections;
using UniRx;
using UnityEngine;

public class OnNext_Sample : MonoBehaviour
{
    Subject<object> s = new Subject<object>();
    void Start()
    {
        s.Subscribe(_ => { Debug.Log("message : " + _); }).AddTo(this); //지정한 GameObject(this)가 파기되면 이 스트림을 Dispose 한다.
        StartCoroutine(LetsGo());
        s.OnNext("Im in Start bebe!");
        s.OnNext("Second Start bebe!");
    }

    private IEnumerator LetsGo()
    {
        s.OnNext("OnNext!");
        yield return new WaitForSeconds(1);
        s.OnNext("OnNext!");
        yield return new WaitForSeconds(1);
    }
}
/*///실행결과////
OnNext!
Im in Start bebe!
Second Start bebe!
OnNext!
////////////*/