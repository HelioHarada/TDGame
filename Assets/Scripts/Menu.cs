using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI MoneyUI;
    [SerializeField] Animator anim;

    private bool isMenuOpen = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void ToggleMenu()
    {   
        isMenuOpen = !isMenuOpen;
        anim.SetBool("MenuToggle", isMenuOpen);
    }

    private void OnGUI()
    {
        MoneyUI.text = LevelManager.main.money.ToString();
    }

    public void SetSelected()
    {
        
    }

}
