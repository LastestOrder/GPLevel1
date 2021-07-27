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
            
        }

       
        if (temp.tag == "MoveBlock")
        {
            Destroy(gameObject);
            
        }
    }



}
