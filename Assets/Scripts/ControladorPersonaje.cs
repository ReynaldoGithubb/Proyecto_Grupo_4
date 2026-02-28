using UnityEngine;
using TMPro;

public class ControlJugador : MonoBehaviour
{
    public float velocidad = 8f;
    public float fuerzaSalto = 12f;
    public TextMeshProUGUI textoContador;

    private int n_Cake = 0, n_Donuts = 0, n_Cookie = 0, n_Ice = 0, n_Lollipop = 0, n_Piece = 0, n_Cupcakes = 0;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        ActualizarTextoUI();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            string nombre = other.gameObject.name;

            if (nombre == "Cake") n_Cake++;
            else if (nombre == "Donuts") n_Donuts++;
            else if (nombre == "Cookie") n_Cookie++;
            else if (nombre == "Ice_cream") n_Ice++;
            else if (nombre == "Lollipop") n_Lollipop++;
            else if (nombre == "Piece_cake") n_Piece++;
            else if (nombre == "Cupcakes") n_Cupcakes++;

            ActualizarTextoUI();
            Destroy(other.gameObject);
        }
    }

    void ActualizarTextoUI()
    {
        textoContador.text = $"Cake: {n_Cake} | Donuts: {n_Donuts} | Cookie: {n_Cookie} | Ice: {n_Ice} | Loll: {n_Lollipop} | Piece: {n_Piece} | Cup: {n_Cupcakes}";
    }
}