using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite_Spawn : MonoBehaviour
{
    public GameObject _dynamite; //Объект динамит
    public Transform _dynamiteSpawnPalce; //Место в котором будет появляться динамит
    public int count = 0;

    // Start is called before the first frame update

    void Update()
    {
        if (count == 0)
        {
            GameObject temp = Instantiate(_dynamite, _dynamiteSpawnPalce.position, Quaternion.identity);
            count = 1;
        }


        //if (count == 0)
        //{
        //    Instantiate(_dynamite, _dynamiteSpawnPalce.position, _dynamiteSpawnPalce.rotation);
        //    count = 1;
        //}
    }
    
}
