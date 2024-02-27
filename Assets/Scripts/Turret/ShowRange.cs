using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRange : MonoBehaviour
{
    public Color circleColor = Color.blue;
    public float targetingRange = 1.0f;
    public int numSegments = 64;

    private LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();

        // Definir a cor do círculo
        

        // Definir a largura da linha
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        // Desenhar o círculo
        // DrawCircle(transform.position, targetingRange, numSegments);
    }


    // Função para desenhar um círculo com um centro, raio e número de segmentos dados
    public void DrawCircle(Vector3 center, float radius, int segments = 64)
    {
 
        lineRenderer.positionCount = segments + 1;
        lineRenderer.startColor = circleColor;
        lineRenderer.endColor = circleColor;

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

    public void ClearCircle()
    {
        // lineRenderer.positionCount = 0;
    }

    
}
