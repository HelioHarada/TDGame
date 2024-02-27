using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager main;

    [Header("References")]
    // [SerializeField] private GameObject[] towerPrefabs;
    [SerializeField]  private ConfigTurrent[] turrents;

    private int selectedTower = 0;
  
    private void Awake()
    {
        main = this;
    }

    public void SetTurrent(int _selecedTurrent)
    {
   
        selectedTower = _selecedTurrent;
    }

    public ConfigTurrent GetSelectedTower()
    {
        return turrents[selectedTower];
    }

   
}
