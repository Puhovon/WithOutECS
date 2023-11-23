using System;
using _Player.Scripts;
using UnityEngine;


public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int _currentHealth;

    public int MaxHealth => maxHealth;
    public int CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value;
    }

    private void Start()
    {
        _currentHealth = maxHealth;
    }

    public void ApplyDamage(int damage)
    {
        print("Apply damage");
        _currentHealth -= damage;
    }
}
