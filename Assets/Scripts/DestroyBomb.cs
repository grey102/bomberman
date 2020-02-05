using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBomb : MonoBehaviour
{
    public GameObject explosionPrefab;

    void Start()
    {
        Invoke("Explode", 3f);
    }

    void Update()
    {

    }

    void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity); //1

        GetComponent<SpriteRenderer>().enabled = false; //2
        transform.Find("Collider").gameObject.SetActive(false); //3
        Destroy(gameObject, .3f); //4
    }
}
