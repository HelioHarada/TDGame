using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TotemSlow : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform turrentRotationPoint;
    [SerializeField] LayerMask enemyMask;
 
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

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startColor = circleColor;
        lineRenderer.endColor = circleColor;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        
    }

    void Update()
    {

        DrawCircle(transform.position, targetingRange, numSegments);
        
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

    private void DrawCircle(Vector3 center, float radius, int segments)
    {
        lineRenderer.positionCount = segments + 1;

        float angleIncrement = 2f * Mathf.PI / segments;

        for (int i = 0; i <= segments; i++)
        {
            float angle = i * angleIncrement;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            Vector3 pos = center + new Vector3(x, y, 0f);
            lineRenderer.SetPosition(i, pos);
        }
    }



}
