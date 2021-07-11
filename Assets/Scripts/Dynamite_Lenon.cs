using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite_Lenon : MonoBehaviour
{
    public GameObject _dynamite; //Объект динамит
    public Transform _dynamiteSpawnPalce; //Место в котором будет появляться динамит
    public Transform _Lemon;
    
    private int count = 0;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {        
        GameObject temp = Instantiate(_dynamite, _dynamiteSpawnPalce.position, Quaternion.identity);
        _dynamite.transform.position = _Lemon.transform.position;
        //_dynamite.Rigidbody.useGravity=false;
        _dynamite.GetComponent<Rigidbody>().useGravity = false;
        
    }
    
}

