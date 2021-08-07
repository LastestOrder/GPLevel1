using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public Transform[] _Lives;
    PlayerMove _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerMove>();
        _Lives = new Transform[transform.childCount];

        for (int i = 0; i<_Lives.Length;i++)
        {
            _Lives[i] = transform.GetChild(i);
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < _Lives.Length; i++)
        {
            if(i<_player._Lives)
            {
                _Lives[i].gameObject.SetActive(true);
            }
            else
            {
                _Lives[i].gameObject.SetActive(false);
            }
        }

    }


}
