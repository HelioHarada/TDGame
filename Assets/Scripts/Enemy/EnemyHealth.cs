using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [Header("Attributes")]
    [SerializeField] private int hitPoint = 2;
    [SerializeField]private int valueMoney = 20;

    private bool isDestroyed = false;
    // Start is called before the first frame update

    public void TakeDamege(int dmg)
    {
        hitPoint -=dmg;

        if(hitPoint <= 0 && !isDestroyed){
            EnemySpawn.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseMoney(valueMoney);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
