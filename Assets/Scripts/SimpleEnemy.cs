using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public float velocidad = 3f;

    void Update()
    {
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);
    }
}
