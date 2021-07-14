using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite_Lenon : MonoBehaviour
{
    public GameObject _dynamite; //Объект динамит
    public Transform _dynamiteSpawnPalce; //Место в котором будет появляться динамит
    public Transform[] _Lemon;

    public int count_dyna = 0;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        GameObject temp = collision.gameObject;
        if (temp.tag == "Dynamite")
        {
            //GameObject temp2 = Instantiate(_dynamite, _dynamiteSpawnPalce.position, Quaternion.identity);
            count_dyna += 1;
        }
    }

    
}

