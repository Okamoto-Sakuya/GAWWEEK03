using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // ìGè¡Ç∑
            Destroy(gameObject);       // íeè¡Ç∑
        }
    }
}