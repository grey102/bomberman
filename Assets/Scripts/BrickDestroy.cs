using UnityEngine;

public class BrickDestroy : MonoBehaviour
{
    public GameObject BrickDeathEffectPrefab;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            Destroy(gameObject);
            Instantiate(BrickDeathEffectPrefab, transform.position, transform.rotation);
        }
    }
}
