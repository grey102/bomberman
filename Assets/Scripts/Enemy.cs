using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool deadEnemy = false;

    void Update()
    {
        Vector3 MaxPozY = new Vector3(1f, 3f, 1f);
        transform.position = Vector3.MoveTowards(transform.position, MaxPozY, 1f * Time.deltaTime);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (!deadEnemy && other.CompareTag("Explosion"))
        {
            deadEnemy = true;
            Destroy(gameObject);
        }
    }

}