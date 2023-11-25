using UnityEngine;

public class AidKit : MonoBehaviour
{
    [SerializeField] private int heal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ICanHeal canHeal))
        {
            print("ApplyHeal");
            canHeal.ApplyHeal(heal);
        }
    }
}
