using _Player.Scripts;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private int damage;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagable damagable))
        {
            damagable.ApplyDamage(damage);
        }
    }
}
