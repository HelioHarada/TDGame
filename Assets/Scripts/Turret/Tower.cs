using System;
using UnityEngine;

[Serializable]
public class ConfigTurrent 
{   
    public string name;
    public int cost;
    public GameObject prefab;

    public ConfigTurrent(string _name, int _cost, GameObject _prefab)
    {
        name = _name;
        cost = _cost;
        prefab = _prefab;
    }
}
