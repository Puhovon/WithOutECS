using _Player.Scripts;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private int damage;
    
    private void OnTriggerEnter(Collider other)
    {
        print($"{other.transform.name}");
        if (other.TryGetComponent(out IDamagable damagable))
        {
            print("ApplyDamage");
            damagable.ApplyDamage(damage);
        }
    }
}
