using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header ("Gun to Player")]
    [SerializeField] Transform gunTransform;
    [SerializeField] SpriteRenderer gunSkin;
    [SerializeField] GameObject playerP;   
    void Start()
    {
        gunTransform = GetComponent<Transform>();
        gunSkin = GetComponent<SpriteRenderer>();
        playerP = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        SeePlayer();
    }
    void SeePlayer()
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
    }
}
