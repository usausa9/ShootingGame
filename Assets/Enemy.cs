using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy�̗̑͗p�ϐ�
    private int enemyHp;

    // Start is called before the first frame update
    void Start()
    {
        // ��������HP��ݒ�
        enemyHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // HP��0�ȉ��ɂȂ�����
        if (enemyHp <= 0)
        {
            // ������
            Destroy(this.gameObject);
        }
    }
}
