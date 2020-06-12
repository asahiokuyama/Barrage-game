using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireMissile : MonoBehaviour
{
    public GameObject enemyMissilePrefab;
    public float missileSpeed;
    private int timeCount = 0;

    public Vector3 pos;

    float time = 0;

    void Update()
    {
        time += Time.deltaTime;
        timeCount += 1;


        if (time > 3)
        {
            transform.Rotate(new Vector3(pos.x, pos.y, pos.z) * Time.deltaTime);
            if(time > 9)
            {
                time = 0;
            }
        }

        // 「%」と「==」の意味を復習しましょう！（ポイント）
        if (timeCount % 5 == 0)
        {
            // 敵のミサイルを生成する
            GameObject enemyMissile = Instantiate(enemyMissilePrefab, transform.position, Quaternion.identity);

            Rigidbody enemyMissileRb = enemyMissile.GetComponent<Rigidbody>();

            // ミサイルを飛ばす方向を決める。「forward」は「z軸」方向をさす（ポイント）
            enemyMissileRb.AddForce(transform.forward * missileSpeed);

            // ３秒後に敵のミサイルを削除する。
            Destroy(enemyMissile, 3.0f);
        }
    }

   
}
