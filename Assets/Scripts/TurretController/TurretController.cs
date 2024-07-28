using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _firePoint;
    [SerializeField] private float _cooldown;
    private Rigidbody _rigidbody;
    private float _cooldownTimer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _cooldownTimer = _cooldown;
    }

    private void Update()
    {
        transform.LookAt(_player.transform);
        _cooldownTimer += Time.deltaTime;
        if(_cooldownTimer >= _cooldown)
        {
            Shoot();
            _cooldownTimer = 0;
        }

    }

    private void Shoot()
    {
        GameObject bulletToShoot = Instantiate(_bullet, _firePoint.transform.position, Quaternion.identity);
        bulletToShoot.GetComponent<BulletController>().SetTarget(_player).InitializeBullet();
    }
}
