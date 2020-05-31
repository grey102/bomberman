using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool dead = false;

    void Update()
    {
        Vector3 MaxPozY = new Vector3(0, 3f, 1f);
        transform.position = Vector3.MoveTowards(transform.position, MaxPozY, 1f * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!dead && other.CompareTag("Explosion"))
        {
            dead = true;
            Destroy(gameObject);
        }
    }

}