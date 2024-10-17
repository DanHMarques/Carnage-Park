using System.Collections;
using UnityEngine;

public class Enemy_Close : MonoBehaviour
{
    [Header ("Follow Player")]
    [SerializeField] public Transform target;
    [SerializeField] public GameObject player;
    public bool inRay, inAttack;
    public float ray = 1.5f;
    public float speed;
    public float maxSpeed = 5f;
    [SerializeField] LayerMask playerL;
    
    private void Start()
    {
        speed = maxSpeed;
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
    }
    void Update()
    {
        Moviment();
        Shoot();
    }
    void Moviment()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        transform.eulerAngles = target.position.x > transform.position.x ? Vector3.zero : target.position.x < transform.position.x ? Vector3.up * 180 : transform.eulerAngles;
    }
    void Shoot()
    {
        inRay = Physics2D.OverlapCircle(transform.position, ray, playerL);
        if (inRay && !inAttack) 
        {
            inAttack = true;
            print("Atacou");
            StartCoroutine(Stop());
        }
    }
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, ray);
    }
    IEnumerator Stop()
    {
        speed = 0;
        yield return new WaitForSeconds(1.5f);
        speed = maxSpeed;
        inAttack = false;
        yield return new WaitForSeconds(0.25f);
    }
}
