using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int bulletSpeed;
    private PlayerControllerE _playerController;
    
    private void Start()
    {
        _playerController = transform.parent.GetComponent<PlayerControllerE>();
        _playerController.attack.AddListener(OnShoot);
    }

    private void OnShoot()
    {
        GameObject instBullet = Instantiate(bullet, transform.position, transform.parent.rotation);
        instBullet.transform.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }
}
