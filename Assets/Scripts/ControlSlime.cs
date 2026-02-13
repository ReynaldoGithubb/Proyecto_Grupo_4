using UnityEngine;

public class ControlSlime : MonoBehaviour
{
    [Header("Configuracion de Movimiento")]
    public float velocidad = 7f;
    public float fuerzaSalto = 15f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        float mover = Input.GetAxis("Horizontal");

        
        rb.linearVelocity = new Vector2(mover * velocidad, rb.linearVelocity.y);

        
        if (mover > 0)
        {
            sr.flipX = false; 
        }
        else if (mover < 0)
        {
            sr.flipX = true; 
        }

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }
    }
}