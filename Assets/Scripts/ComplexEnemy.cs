using UnityEngine;

public class ComplexEnemy : MonoBehaviour
{
    public float velocidad = 3f;
    public float distanciaDeteccion = 5f;
    public Transform objetivo; 

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (objetivo != null)
        {
            float distanciaAlJugador = Vector2.Distance(transform.position, objetivo.position);

            if (distanciaAlJugador < distanciaDeteccion)
            {
                float direccion = (objetivo.position.x > transform.position.x) ? 1 : -1;

                transform.Translate(Vector2.right * direccion * velocidad * Time.deltaTime);

                if (direccion > 0)
                {
                    sr.flipX = false; 
                }
                else
                {
                    sr.flipX = true;  
                }
            }
        }
    }
}