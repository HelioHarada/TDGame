using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

public class Turrent : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform turrentRotationPoint;
    [SerializeField] LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private ShowRange showRange;
   

    [Header("atrribute")]
    [SerializeField] private float targetingRange = 3f;
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private float fireRate = 1f; // bullets per second
    [SerializeField] private int dmg = 1; // bullets per second
    [SerializeField] private float bulletSpeed = 1f; // bullets per second

    // Start is called before the first frame update

    private Transform target;
    private float TimeUntllFire;



    void Awake()
    {
         showRange = GetComponent<ShowRange>();
    }



    // Update is called once per frame
    void Update()
    {
         
    
        if(target == null)
        {
            FindTartget();
            return;
        }
        RotateTowardsTarget();

        if(!CheckTargeRange())
        {
            target = null;
        }else{
            TimeUntllFire += Time.deltaTime;

            if(TimeUntllFire >= 1f / fireRate)
            {
                Shoot();
                TimeUntllFire = 0;
            }
        }
        
        
       
    }

    private bool CheckTargeRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }
    private void FindTartget()
    {
        // Explicação
        /*
        RaycastHit2D[] hits: Este é um array que armazenará as informações sobre as colisões encontradas pelos raycasts. Cada elemento do array corresponderá a uma colisão detectada.
        Physics2D.CircleCastAll: Esta função lança um círculo de raycasts em um ambiente 2D do Unity e retorna todas as colisões encontradas dentro do círculo.
        */
        /*
        Parâmetro 1: origin (Vector2) - A posição de onde o círculo de raycasts será lançado.
        Parâmetro 2: radius (float) - O raio do círculo de raycasts.
        Parâmetro 3: direction (Vector2) - A direção do círculo de raycasts. Neste caso, parece haver um erro, pois está sendo passada a posição do objeto como a direção, o que geralmente não é típico em uma operação de CircleCast.
        Parâmetro 4: distance (float) - O comprimento dos raycasts. Geralmente é definido como zero, pois o círculo de raycasts já define o raio.
        Parâmetro 5: layerMask (int) - Uma máscara de camada que especifica quais camadas de colisão devem ser consideradas ao lançar os raycasts. Apenas objetos nas camadas especificadas serão detectados pelas colisões.
        */
      
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);

        if(hits.Length > 0)
        {
            target = hits [0].transform;
        }
    }
    
    // private void RotateTowardsTarget()
    // {
    //     float angle = Mathf.Atan2(target.position.y - transform.position.y,target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
    //     /*
    //         Quaternion é um tipo de dado em Unity que representa uma rotação na forma de um vetor de quatro componentes: (x, y, z, w).
    //     */
    //     Quaternion targetRotation = Quaternion.Euler(new Vector3(0f,0f, angle));
    //     turrentRotationPoint.rotation = targetRotation;
    // }
    
    // Testar codigo mais eficiente segundo a IA.
   
    private void RotateTowardsTarget()
    {
        // Calcula a direção para o alvo
        Vector2 direction = target.position - transform.position;

        // Calcula o ângulo em radianos
        float angleRadians = Mathf.Atan2(direction.y, direction.x);

        // Converte o ângulo para graus
        float angleDegrees = angleRadians * Mathf.Rad2Deg  - 90f;

        // Cria uma rotação em torno do eixo z
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angleDegrees);

        // Aplica a rotação ao objeto atual
        turrentRotationPoint.rotation = Quaternion.RotateTowards(turrentRotationPoint.rotation, targetRotation, rotationSpeed*Time.deltaTime);
    }
  

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        // Config bullet
        bulletScript.SetBulletConfig(bulletSpeed, dmg);
        bulletScript.SetTarget(target);
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

   private void OnMouseEnter()
    {        
        Debug.Log(showRange);
        
        showRange.DrawCircle(transform.position,targetingRange);
    }

    private void OnMouseExit()
    {        
    
        showRange.ClearCircle();
    }
    
    // private void OnMouseDown()
    // {
    //     showRange.DrawCircle(transform.position,targetingRange);
    // }

    // private void OnMouseUp()
    // {
    //      showRange.ClearCircle();
    // }


    

}
