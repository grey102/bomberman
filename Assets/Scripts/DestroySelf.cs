using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float Delay = 0.5f;

    void Start ()
    {
        Destroy (gameObject, Delay);
    }
}
