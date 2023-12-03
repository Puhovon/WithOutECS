using System;
using _Player.Scripts;
using Resourses.Scripts;
using UnityEngine;


public class Health : MonoBehaviour, IDamagable
{
    [SerializeField]
    private StatsUpdate statsUpdate;
    [SerializeField] private int maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private Shoot _shoot;
    private PlayerStats _playerStats;
    
    private Action _action;
    public int MaxHealth => maxHealth; 
    public int CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value;
    }

    public void Initialize()
    {
        _currentHealth = maxHealth;
        statsUpdate.DownloadData();
    }

    public void ApplyDamage(int damage)
    {
        print("Apply damage");
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            WriteStatistics();
        }
    }

    private void WriteStatistics()
    {
        _shoot.playerStats.health = _currentHealth;
        statsUpdate.Upload();
    }
}
