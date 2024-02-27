
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
     
     [SerializeField]public float speed = 10f;
    [SerializeField] public float initialSpeed;
     private Transform target;
     private int index = 0;
     
    [SerializeField] private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        target = LevelManager.main.path[index];
        rb = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            index++;
            
            // Final point
            if(index >= LevelManager.main.path.Length)
            {
                EnemySpawn.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }else{
                target = LevelManager.main.path[index];
            }
        }
    }

    void FixedUpdate()
    {
        movement();
    }

    void movement()
    {
        Vector2 direction = (target.position - transform.position).normalized;
       
        rb.velocity = direction * speed;
  
    }

    public void SetSpeed(float slowPercentSpeed)
    {
        speed = speed* slowPercentSpeed;
    }

        public void ResetSpeed()
    {
        speed = initialSpeed;
    }
}
