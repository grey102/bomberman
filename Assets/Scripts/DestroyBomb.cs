﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBomb : MonoBehaviour
{
    public GameObject explosionPrefab;
	public LayerMask Blocks;


    void Start()
    {
        Invoke("Explode", 3f);
    }

	 public void Explode()
	 {
		 Instantiate(explosionPrefab, transform.position, Quaternion.identity); //1

		StartCoroutine(CreateExplosions(Vector3.up));
		StartCoroutine(CreateExplosions(Vector3.right));
		StartCoroutine(CreateExplosions(Vector3.down));
		StartCoroutine(CreateExplosions(Vector3.left));
		
		GetComponent<SpriteRenderer>().enabled = false; //2
		 transform.Find("Collider").gameObject.SetActive(false); //3
		 Destroy(gameObject, .3f); //4
	 }

	private IEnumerator CreateExplosions(Vector3 direction)
	{
        //1
        for (int i = 1; i < 3; i++)
        {
            //2
            RaycastHit hit;
            //3
            Physics.Raycast(transform.position + new Vector3(0, .5f, 0), direction, out hit,
              i, Blocks);

            //4
            if (!hit.collider)
            {
                Instantiate(explosionPrefab, transform.position + (i * direction),
                  //5 
                  explosionPrefab.transform.rotation);
                //6
            }
            else
            { //7
                break;
            }

            //8
            yield return new WaitForSeconds(.05f);
        }

    }

}