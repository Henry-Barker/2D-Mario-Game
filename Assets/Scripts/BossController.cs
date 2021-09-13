using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject shotPrefab;
    public float shotForce;

    public float timeBetweenShots;

    [SerializeField]
    private float shotTimer;

    private EnemyHP bossHP;
    private GameObject eyeBall;
    public GameObject goalPole;

    // Start is called before the first frame update
    void Start()
    {
        shotTimer = timeBetweenShots;

        bossHP = transform.GetChild(0).GetComponent<EnemyHP>();
        eyeBall = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer -= Time.deltaTime;
        if(shotTimer <= 0)
        {
            shotTimer = timeBetweenShots;
            Shoot();
        }

        if (bossHP.isDead)
        {
            Destroy(eyeBall);
            goalPole.SetActive(true);
        }
    }

    void Shoot()
    {
        GameObject laser = Instantiate(shotPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb2d = laser.GetComponent<Rigidbody2D>();
        rb2d.AddForce(firePoint.up * shotForce, ForceMode2D.Impulse);
    }
}
