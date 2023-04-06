using System.Collections;
using UniRx;
using UnityEngine;

public class OnNext_Sample : MonoBehaviour
{
    Subject<object> s = new Subject<object>();
    void Start()
    {
        s.Subscribe(_ => { Debug.Log("message : " + _); });
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