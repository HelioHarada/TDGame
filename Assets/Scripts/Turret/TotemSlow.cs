using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TotemSlow : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform turrentRotationPoint;
    [SerializeField] LayerMask enemyMask;
    [SerializeField] private ShowRange showRange;
 
    [Header("atrribute")]
    [SerializeField] private float targetingRange = 3f;
    [SerializeField] private float fireRate = 4f; // bullets per second
    [SerializeField] private int dmg = 1; // dmg

    [SerializeField] private float slowSpeed = 0.5f;
    [SerializeField] private float SlowDuration = 2f;

    private LineRenderer lineRenderer;

    public int numSegments = 64;
    public Color circleColor = Color.red;

     private float TimeUntllFire;


    void Awake()
    {
         showRange = GetComponent<ShowRange>();
    }


    void Update()
    {

    
        
        TimeUntllFire += Time.deltaTime;

        if(TimeUntllFire >= 1f / fireRate)
        {
            FreezeEnemies();
            TimeUntllFire = 0;
        }
    }

    private void FreezeEnemies()
    {
         RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);

         if(hits.Length > 0)
         {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];

                EnemyMovement em = hit.transform.GetComponent<EnemyMovement>();
                em.SetSpeed(slowSpeed);

                StartCoroutine(ResetSpeed(em));
            }
         }
    }

    private IEnumerator ResetSpeed( EnemyMovement em)
    {
        yield return new WaitForSeconds(SlowDuration);
        em.ResetSpeed();
    }

        private void OnDrawGizmosSelected()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }


   private void OnMouseEnter()
    {        
        
        showRange.DrawCircle(transform.position,targetingRange);
    }

    private void OnMouseExit()
    {        
    
        showRange.ClearCircle();
    }


}
