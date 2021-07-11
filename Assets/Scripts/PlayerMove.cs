using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed; //�������� ��������, � � ���������� � ���������
    [SerializeField] private Vector3 _directon; // ����������� ��������

    private void Update()
    {
        _directon.x = Input.GetAxis("Horizontal");
        _directon.z = Input.GetAxis("Vertical");
        _directon.y = Input.GetAxis("Jump");
    }

    private void FixedUpdate()
    {
        var speed = _directon * _speed * Time.deltaTime;
        transform.Translate(speed);
    }
}
