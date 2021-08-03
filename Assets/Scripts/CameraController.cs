using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float _dumping = 1.5f; //отвечает за скольжение камеры
    public Vector3 _offset = new Vector3(1f, -3.5f, -3.5f);
    public bool _isLeft;
    private Transform _player;
    private int _lastX;

    private void Start()
    {
        _offset = new Vector3(Mathf.Abs(_offset.x),_offset.y, _offset.z);
        FindPlayer(_isLeft);
    }

    public void FindPlayer(bool playerIsLeft)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _lastX = Mathf.RoundToInt(_player.position.x);
        if (playerIsLeft)
        {
            transform.position = new Vector3(_player.position.x - _offset.x, transform.position.y - _offset.y, _player.position.z - _offset.z);
        }
        //else
        //{
        //    transform.position = new Vector3(_player.position.x - _offset.x, transform.position.y - _offset.y, _player.position.z + _offset.z);
        //}
    }

    private void Update()
    {
        if (_player)
        {
            int currentX = Mathf.RoundToInt(_player.position.x);
            if (currentX > _lastX) _isLeft = false;
            else if (currentX < _lastX) _isLeft = true;
            _lastX= Mathf.RoundToInt(_player.position.x);

            Vector3 target;
            //if (_isLeft)
            //{
            //target = new Vector3(_player.position.x - _offset.x, _player.position.y - _offset.y, _player.position.z - _offset.z);
            //}
            //else
            //{
            target = new Vector3(_player.position.x - _offset.x, _player.position.y - _offset.y, _player.position.z + _offset.z);
            //}

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, _dumping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}
