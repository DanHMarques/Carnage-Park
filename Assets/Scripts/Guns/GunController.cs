using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("Gun to Player")]
    [SerializeField] Transform gunTransform;
    [SerializeField] SpriteRenderer gunSkin;
    [SerializeField] GameObject playerP;
    [SerializeField] GameObject bullet_Prefab;
    [SerializeField] Enemy_Close enemy_Close;
    [SerializeField] Transform spawnBullet;
    void Start()
    {
        gunTransform = GetComponent<Transform>();
        gunSkin = GetComponent<SpriteRenderer>();
        playerP = GameObject.FindGameObjectWithTag("Player");
        spawnBullet = GetComponentInChildren<Transform>();
    }
    void Update()
    {
        SeePlayer_Shoot();
    }
    void SeePlayer_Shoot()
    {
        Vector3 playerPos = playerP.transform.position;
        Vector3 direction = playerPos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (playerPos.x + 0.25f < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            gunTransform.rotation = Quaternion.Euler(0, 0, angle);
            gunSkin.flipY = true;
        }
        else if (playerPos.x - 0.25f > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            gunTransform.rotation = Quaternion.Euler(0, 0, angle);
            gunSkin.flipY = false;
        }

        //Instanciar o projétil em direção ao player
        if (enemy_Close.inAttack)
        {
            Instantiate(bullet_Prefab, spawnBullet.position, transform.rotation);
            enemy_Close.inAttack = false;
        }
    }
}
