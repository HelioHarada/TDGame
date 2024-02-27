using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plot : MonoBehaviour
{
    private GameObject tower;
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
 
    [SerializeField] private Color hoverColor;
    private Color startColor;



    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); 
       
        startColor = sr.color;
    }
    private void OnMouseEnter(){
        sr.color = hoverColor;
       
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown(){
        if(tower != null) return;

        ConfigTurrent towerToBuild = BuildManager.main.GetSelectedTower();

        if(towerToBuild.cost >= LevelManager.main.money)
        {
            Debug.Log("No Souls to create a tower");
            return;
        }

        LevelManager.main.SpendMoney(towerToBuild.cost);
        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);

       
    }

  
}
