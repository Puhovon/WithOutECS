using System;
using Resourses.Scripts;
using UnityEngine;

public class BootStrap : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private StatsUpdate firebase;
    [SerializeField] private UI ui;
    
    public void Start()
    {
        if (PlayerPrefs.HasKey("ID"))
        {
            print(PlayerPrefs.GetString("ID"));
        }
        else
        {
            PlayerPrefs.SetString("ID", $"{Guid.NewGuid()}");
            print(PlayerPrefs.GetString("ID"));
        }

        ui.Initialize();
        firebase.Initialize(PlayerPrefs.GetString("ID"));
        playerHealth.Initialize();
    }
}
