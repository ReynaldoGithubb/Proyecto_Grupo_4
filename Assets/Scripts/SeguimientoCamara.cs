using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform objetivo; 
    public float suavizado = 0.125f; 
    public Vector3 desfase = new Vector3(0, 0, -10); 

    void LateUpdate()
    {
        if (objetivo != null)
        {
            
            Vector3 posicionDeseada = objetivo.position + desfase;
            
            Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, suavizado);
            transform.position = posicionSuavizada;
        }
    }
}