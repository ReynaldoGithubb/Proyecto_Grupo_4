using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public float velocidad = 8f;
    public float fuerzaSalto = 12f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float mover = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(mover * velocidad, rb.linearVelocity.y);

        
        anim.SetFloat("p_Velocidad", Mathf.Abs(mover));

       
        if (mover > 0) sr.flipX = false;
        else if (mover < 0) sr.flipX = true;

        bool enAire = Mathf.Abs(rb.linearVelocity.y) > 0.1f;
        anim.SetBool("p_estaSaltando", enAire);

        if (Input.GetButtonDown("Jump") && !enAire)
        {
            rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }
    }
}