using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Block : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dynamite"))
        {
            Destroy(gameObject, 0f);

        }
        //if (collision.gameObject.CompareTag("MoveBlock"))
        //{
        //    Destroy(gameObject, 0f);
        //    //Dynamite_Spawn dynamite_Spawn = _spawn.GetComponent<Dynamite_Spawn>();
        //    //dynamite_Spawn.count -= 1;
        //    //Dynamite_Lenon dynamite_Lenon = _Lemon.GetComponent<Dynamite_Lenon>();
        //}
    }
}
