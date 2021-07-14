using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Dynamite : MonoBehaviour
{
    public GameObject _spawn;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        GameObject temp = collision.gameObject;
        if (temp.tag == "Player")
        {
           Destroy(gameObject, 0f);
            Dynamite_Spawn dynamite_Spawn = _spawn.GetComponent<Dynamite_Spawn>();
            dynamite_Spawn.count -= 1;
            //Dynamite_Lenon dynamite_Lenon = _Lemon.GetComponent<Dynamite_Lenon>();
        }

    }



}
