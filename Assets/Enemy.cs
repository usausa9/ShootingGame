using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemyの体力用変数
    private int enemyHp;

    // Start is called before the first frame update
    void Start()
    {
        // 生成時のHPを設定
        enemyHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // HPが0以下になったら
        if (enemyHp <= 0)
        {
            // きえる
            Destroy(this.gameObject);
        }
    }
}
