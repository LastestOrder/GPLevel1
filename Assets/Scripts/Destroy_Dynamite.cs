using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Dynamite : MonoBehaviour
{
    public GameObject _spawn;
    public Spawner _spawner;
    public GameObject _Explosion;

   
    private void OnCollisionEnter(Collision collision)
    {
        Spawner spawner = _spawn.GetComponent<Spawner>();

        GameObject temp = collision.gameObject;
        if (temp.tag == "Player" )
        {           
           Destroy(gameObject, 0f);
           spawner._dynamitCount = _spawner._dynamitCount - 1;
        }

        if (temp.tag == "MoveBlock")
        {
            Destroy(gameObject, 0f);
            Instantiate(_Explosion, transform.position, Quaternion.identity);
        }
        
    }
   

}
