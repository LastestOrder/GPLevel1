using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Spawner : MonoBehaviour
{
    public GameObject _dynamite;
    public Transform[] _spawnPionts;
    public int _dynamitCount;
    private int _maxdynamiteCount=3;
    public Coroutine spawn;

    private IEnumerator SpawnDynamite(int count)
    {
        while(_dynamitCount<count)
        {
            yield return new WaitForSeconds(Random.Range(1, 6));
            GameObject temp = Create(_dynamite);
            temp.name = "Dynamite";
            _dynamitCount++;
        }
    }

    GameObject Create(GameObject Prefab)
    {
        Vector3 pos = _spawnPionts[Random.Range(1, _spawnPionts.Length)].position;
        return Instantiate(Prefab, pos, Quaternion.identity);
    }
    
    void Start()
    {
        _spawnPionts = GetComponentsInChildren<Transform>();
        if (spawn == null)
        {
            spawn = StartCoroutine(SpawnDynamite(_maxdynamiteCount));
        }
    }

}
