﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    Spaceship spaceship;

    // Use this for initialization
    IEnumerator Start()
    {

        spaceship = GetComponent<Spaceship>();

        spaceship.Move(transform.up * -1);

        if (spaceship.canShot == false)
        {
            yield break;
        }

        while (true)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform shotPositonTransform = transform.GetChild(i);

                spaceship.Shot(shotPositonTransform);
            }
            yield return new WaitForSeconds(spaceship.shotDelay);
        }

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        if (layerName != "Bullet(Player)") return;

        Destroy(c.gameObject);
        spaceship.Explosion();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
