using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite_Lenon : MonoBehaviour
{
    public GameObject _Dynamite; //Объект динамит
        
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

    private void Update()
    {
        if (count_dyna>0)
        {
            _Dynamite.SetActive(true);
        }

        if (count_dyna == 0)
        {
            _Dynamite.SetActive(false);
        }
    }


}

