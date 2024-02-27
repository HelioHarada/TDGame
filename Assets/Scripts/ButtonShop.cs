using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ButtonShop : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI costUI;


   

    public void ToggleMenu()
    {

    }

    private void OnGUI()
    {
        // Debug.Log(costUI.text);
        // if(LevelManager.main.money.ToString() == null) return;
        // costUI.text = LevelManager.main.money.ToString();
    }

    public void SetSelectedTower()
    {

    }

}
