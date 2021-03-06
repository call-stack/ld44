﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public GameStateSO stateSO;

    GameObject player;

    public float bulletSpeed = 0.1f;
    public float dmg = 40f;

    private void OnEnable()
    {
        bulletSpeed = Random.Range(bulletSpeed - 0.03f, bulletSpeed + (0.05f * (stateSO.currentWave + 1)));
    }
    void Start()
    {
        player = FindObjectOfType<playerController>().gameObject;
        Destroy(gameObject, 5f);
    }

    public void Init(float bulletSpeed, float dmg) {
        this.bulletSpeed = bulletSpeed;
        this.dmg = dmg;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(1,0,0) * bulletSpeed);
    }

    private void Update()
    {
        transform.Rotate(Vector3.right, Time.deltaTime * 590);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D collisionRb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (collision.tag == "Player")
        {
            stateSO.reduceMoney(dmg);
            Vector2[] hitVectors = new Vector2[] { Vector2.left, Vector2.right };
            Vector2 hitForce = hitVectors[Random.Range(0, 2)];
            player.GetComponent<Rigidbody2D>().AddForce(hitForce * dmg * 10);
            player.GetComponent<playerController>().particleBlood.Emit((int)dmg);
            Destroy(gameObject);
        }
    }
}
