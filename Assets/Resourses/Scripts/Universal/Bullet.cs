using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Finish"))
            Destroy(gameObject);
    }
}
