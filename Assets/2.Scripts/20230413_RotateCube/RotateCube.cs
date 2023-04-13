using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class RotateCube : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100.0f;
    void Start()
    {
        this.UpdateAsObservable()           // Update()의 타이밍을 알려 Observable
            .SkipUntil(this.OnMouseDownAsObservable())  // 마우스가 클릭 될 때까지 스트림을 무시
            .Select(_ => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")))   // 스트림에 흐르는 인풋값을 마우스 이동량으로 변경
            .TakeUntil(this.OnMouseUpAsObservable())    // 마우스를 놓을 때까지
            .Repeat()   // 마우스를 놓으면 TakeUntil 스트림이 종료되므로 다시 사용할 수 있도록 다시 Subscribe
            .Subscribe(move =>  // 개체를 드래그하여 회전
            {
                transform.rotation =
                Quaternion.AngleAxis(move.y * rotationSpeed * Time.deltaTime, Vector3.right)
                * Quaternion.AngleAxis(move.x * rotationSpeed * Time.deltaTime, -Vector3.up)
                * transform.rotation;
            });
    }
}
