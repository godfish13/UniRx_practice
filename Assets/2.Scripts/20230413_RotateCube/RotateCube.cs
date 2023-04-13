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
        this.UpdateAsObservable()           // Update()�� Ÿ�̹��� �˷� Observable
            .SkipUntil(this.OnMouseDownAsObservable())  // ���콺�� Ŭ�� �� ������ ��Ʈ���� ����
            .Select(_ => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")))   // ��Ʈ���� �帣�� ��ǲ���� ���콺 �̵������� ����
            .TakeUntil(this.OnMouseUpAsObservable())    // ���콺�� ���� ������
            .Repeat()   // ���콺�� ������ TakeUntil ��Ʈ���� ����ǹǷ� �ٽ� ����� �� �ֵ��� �ٽ� Subscribe
            .Subscribe(move =>  // ��ü�� �巡���Ͽ� ȸ��
            {
                transform.rotation =
                Quaternion.AngleAxis(move.y * rotationSpeed * Time.deltaTime, Vector3.right)
                * Quaternion.AngleAxis(move.x * rotationSpeed * Time.deltaTime, -Vector3.up)
                * transform.rotation;
            });
    }
}
