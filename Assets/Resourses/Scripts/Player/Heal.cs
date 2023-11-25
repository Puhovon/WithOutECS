using UnityEngine;

namespace _Player.Scripts
{
    [RequireComponent(typeof(Health))]
    public class Heal : MonoBehaviour, ICanHeal
    {

        private Health _health;
        void Start()
        {
            _health = GetComponent<Health>();
        }

        public void ApplyHeal(int heal)
        {
            if (_health.CurrentHealth + heal > _health.MaxHealth)
                _health.CurrentHealth += _health.CurrentHealth + heal - _health.MaxHealth;
            else
                _health.CurrentHealth += heal;
        }
    }
}
