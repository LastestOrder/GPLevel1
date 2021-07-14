using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Text : MonoBehaviour
{
    public Transform _dynamiteCount;
    public GameObject _Lemon;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        Dynamite_Lenon dynamite_Lenon = _Lemon.GetComponent<Dynamite_Lenon>();

        _dynamiteCount.GetComponent<Text>().text = dynamite_Lenon.count_dyna.ToString();
        //_dynamiteCount.GetComponent<Text>().text=
    }
}
