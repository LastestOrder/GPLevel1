using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Wall : MonoBehaviour
{
    public GameObject _wall;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(_wall);
    }
}
