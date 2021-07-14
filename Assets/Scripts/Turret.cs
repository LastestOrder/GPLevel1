using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform _Player;
    public float _speed;
    public Vector3 _playerPos;
    public float _offset;
    public Quaternion _playerRot;
    public Transform _bulletPosition;
    public GameObject _bullet;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        _offset = 1;
        _speed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        _playerRot = _Player.rotation;
        _playerPos = new Vector3(_Player.position.x + _offset, _Player.position.y, _Player.position.z + _offset);

        //transform.position = Vector3.Lerp(transform.position, Time.deltaTime * _speed);

        transform.LookAt(_Player.position);


    }

    private void OnTriggerStay(Collider other)
    {
       // if (count == 0)
       //{
            GameObject temp = Instantiate(_bullet, _bulletPosition.position, Quaternion.identity);
            count = 1;
       // }
    }
    
}
