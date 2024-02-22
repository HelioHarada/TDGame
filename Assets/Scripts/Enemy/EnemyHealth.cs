using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [Header("Attributes")]
    [SerializeField] private int hitPoint = 2;
    // Start is called before the first frame update

    public void TakeDamege(int dmg)
    {
        hitPoint -=dmg;

        if(hitPoint <= 0){
            EnemySpawn.onEnemyDestroy.Invoke();
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
