using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberMan : MonoBehaviour
{
    private float movementSpeed = 5f;

    //Prefabs
    public GameObject bombPrefab;

    void Update()
    {
        Move();
        //AxisMove();
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

    void AxisMove()
    {
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        //update the position
        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);

        //output to log the position change
        Debug.Log(transform.position);
    }

    void DropBomb()
    {

        Instantiate(bombPrefab, new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y)), transform.rotation);

    }
}

