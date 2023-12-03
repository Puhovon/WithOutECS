using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int bulletSpeed;
    private PlayerControllerE _playerController;
    public PlayerStats playerStats;
    
    private void Start()
    {
        _playerController = transform.parent.GetComponent<PlayerControllerE>();
        _playerController.attack.AddListener(OnShoot);
        var jsonString = PlayerPrefs.GetString("Stats");
        if (!jsonString.Equals(String.Empty, StringComparison.Ordinal))
            playerStats = JsonUtility.FromJson<PlayerStats>(jsonString);
        else
            playerStats = new PlayerStats();
        print(playerStats);
        print(jsonString);
    }

    private void OnShoot()
    {
        GameObject instBullet = Instantiate(bullet, transform.position, transform.parent.rotation);
        instBullet.transform.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        playerStats.shootCount += 1;
    }
}
