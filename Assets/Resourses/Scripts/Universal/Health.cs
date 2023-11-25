using System;
using _Player.Scripts;
using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private Shoot _shoot;
    private Action _action;
    public int MaxHealth => maxHealth; 
    public int CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value;
    }

    private void Start()
    {
        _currentHealth = maxHealth;
        var f = StatsSave.DownLoad();
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
        var json = JsonUtility.ToJson(_shoot._playerStats);
        PlayerPrefs.SetString("Stats", json);
        var s = StatsSave.Upload(json);
    }
}
