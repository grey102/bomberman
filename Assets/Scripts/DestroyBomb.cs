using System.Collections;
using UnityEngine;

public class DestroyBomb : MonoBehaviour
{
	public GameObject explosion1Prefab;
	public LayerMask levelMask;
	private bool exploded = false;

	void Start()
	{
		Invoke("Explode", 3f);
	}

	 public void Explode()
	 {
		 Instantiate(explosion1Prefab, transform.position, Quaternion.identity); 

		StartCoroutine(CreateExplosions(Vector3.up));
		StartCoroutine(CreateExplosions(Vector3.right));
		StartCoroutine(CreateExplosions(Vector3.down));
		StartCoroutine(CreateExplosions(Vector3.left));
		
		GetComponent<SpriteRenderer>().enabled = false; 
		exploded = true;
		transform.Find("BoxCollider").gameObject.SetActive(false);
		Destroy(gameObject, .3f); 
		
	 }

	private IEnumerator CreateExplosions(Vector3 direction)
	{
		for (int i = 1; i < 3; i++)
		{
			RaycastHit hit;
			Physics.Raycast(transform.position + new Vector3(0, 0, .5f), direction, out hit, i, levelMask);

			if (!hit.collider)
			{
				Instantiate(explosion1Prefab, transform.position + (i * direction), explosion1Prefab.transform.rotation);
			}
			else
			{
				break;
			}

			yield return new WaitForSeconds(.05f);
		}

	}

	public void OnTriggerEnter(Collider other)
	{
		if (!exploded && other.CompareTag("Explosion"))
		{ 
			CancelInvoke("Explode");
			Explode();
		}

	}

}