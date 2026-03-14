using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public float velocidad = 2f;
    public float distanciaMovimiento = 3f;
    public float distanciaDeteccionPared = 0.5f; 
    public LayerMask capaSuelo; 

    private Vector2 posicionInicial;
    private int direccion = 1;
    private SpriteRenderer sr;

    void Start()
    {
        posicionInicial = transform.position;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        transform.Translate(Vector2.right * velocidad * direccion * Time.deltaTime);

        RaycastHit2D choque = Physics2D.Raycast(transform.position, Vector2.right * direccion, distanciaDeteccionPared, capaSuelo);

        if (choque.collider != null || Vector2.Distance(posicionInicial, transform.position) > distanciaMovimiento)
        {
            direccion *= -1;
            posicionInicial = transform.position; 

            if (direccion > 0) sr.flipX = false;
            else sr.flipX = true;
        }
    }
}