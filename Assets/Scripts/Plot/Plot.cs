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

        GameObject towerToBuild = BuildManager.main.GetSelectedTower();
        tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
    }

  
}
