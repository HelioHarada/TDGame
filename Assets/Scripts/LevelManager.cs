using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform[] path;
    public Transform startPoint;

    public int money = 0;
    void Awake()
    {
        main = this;

    }

    private void Start()
    {
        money = 500;
    }

    public void IncreaseMoney(int amount)
    {
        money += amount;
    }

    public bool SpendMoney(int amount)
    {
   

        if(money >= amount ){

            money -= amount;
            return true;
        }else{
            
            Debug.Log("No Souls enough");
            return false;
        }

     
    }
}
