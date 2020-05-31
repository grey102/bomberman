using UnityEngine;

public class BomberMan : MonoBehaviour
{

    public bool dead = false;

    public GameObject bombPrefab;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + new Vector3(-0.06f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(0.06f, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = transform.position + new Vector3(0, 0.06f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + new Vector3(0, -0.06f, 0);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            DropBomb();
        }
    }

    void DropBomb()
    {
        Instantiate(bombPrefab, new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), transform.position.z), transform.rotation);
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

