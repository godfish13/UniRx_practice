using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Tester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var mySubject = GetComponent<TestSubject>().mySubject;
        mySubject.Subscribe(n => { SomeMethod(n); }, ex => { Debug.Log("Error"); } ,() => { Debug.Log("Completed"); });
    }
    private void SomeMethod(int n)
    {
        Debug.Log(n);
    }
}
