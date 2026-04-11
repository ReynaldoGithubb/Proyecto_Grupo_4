using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float posicionInicial;
    public GameObject camara;
    public float intensidad;

    void Start()
    {
        posicionInicial = transform.position.x;
        if (camara == null) camara = Camera.main.gameObject;
    }

    void LateUpdate()
    {
        float distancia = (camara.transform.position.x * intensidad);
        transform.position = new Vector3(posicionInicial + distancia, transform.position.y, transform.position.z);
    }
}