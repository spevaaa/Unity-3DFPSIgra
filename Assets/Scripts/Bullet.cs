using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
