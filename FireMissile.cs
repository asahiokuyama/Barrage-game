﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMissile : MonoBehaviour
{
    public GameObject missilePrefab;
    public float missileSpeed;
    public AudioClip fireSound;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // プレハブからミサイルオブジェクトを作成し、それをmissileという名前の箱に入れる。
            GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity) as GameObject;

            Rigidbody missileRb = missile.GetComponent<Rigidbody>();

            missileRb.AddForce(transform.forward * missileSpeed);

            AudioSource.PlayClipAtPoint(fireSound, transform.position);

            // 発射したミサイルを２秒後に破壊（削除）する。
            Destroy(missile, 2.0f);
        }
    }
}
