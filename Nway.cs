using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nway : MonoBehaviour
{
    public GameObject enemyFireMissilePrefab;
    public int wayNumber;

    void Start()
    {
        for (int i = 0; i < wayNumber; i++)
        {
            // ★改良
            GameObject enemyFireMissile = Instantiate(enemyFireMissilePrefab, transform.position, Quaternion.Euler(0, -30 + (15 * i), 0));

            // ★追加
            // SetParent()は親子関係を作るメソッド（ポイント）
            // 『このスクリプトが付いているNWayオブジェクトをenemyFireMissileクローンの親に設定する。』
            enemyFireMissile.transform.SetParent(this.gameObject.transform);
        }
    }
}
