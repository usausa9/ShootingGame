using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy‚Ì‘Ì—Í—p•Ï”
    private int enemyHp;

    // Start is called before the first frame update
    void Start()
    {
        // ¶¬‚ÌHP‚ğİ’è
        enemyHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // HP‚ª0ˆÈ‰º‚É‚È‚Á‚½‚ç
        if (enemyHp <= 0)
        {
            // ‚«‚¦‚é
            Destroy(this.gameObject);
        }
    }
}
