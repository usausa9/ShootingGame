using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 子オブジェのサイズを入れる
    private float Left, Right, Top, Bottom;
    // カメラから見た画面左下,右上の座標
    Vector3 LeftBottom;
    Vector3 RightTop;

    // Start is called before the first frame update
    void Start()
    {
        // 子オブジェクトの数だけループ処理を行う
        foreach (Transform child in gameObject.transform)
        {
            // 子オブジェの中で一番右の位置なら
            if (child.localPosition.x >= Right)
            {
                // 子オブジェのローカル座標を右端用の変数に代入する
                Right = child.transform.localPosition.x;
            }
            // 子オブジェの中で一番左の位置なら
            if (child.localPosition.x <= Left)
            {
                // 子オブジェのローカル座標を右端用の変数に代入する
                Left = child.transform.localPosition.x;
            }
            // 子オブジェの中で一番上の位置なら
            if (child.localPosition.x >= Top)
            {
                // 子オブジェのローカル座標を右端用の変数に代入する
                Top = child.transform.localPosition.z;
            }
            // 子オブジェの中で一番下の位置なら
            if (child.localPosition.x <= Bottom)
            {
                // 子オブジェのローカル座標を右端用の変数に代入する
                Bottom = child.transform.localPosition.z;
            }
        }

        // カメラとプレイヤーの距離を測る
        var distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        // スクリーン画面の位置を設定
        LeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));
    }

    // Update is called once per frame
    void Update()
    {
        
        // プレイヤーのワールド座標を取得
        Vector3 pos = transform.position;

        // キーが入力されたとき
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += 0.01f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= 0.01f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.z += 0.01f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.z -= 0.01f;
        }
        transform.position = new Vector3 (
            Mathf.Clamp(pos.x, LeftBottom.x + transform.localScale.x - Left, RightTop.x - transform.localScale.x - Right),
            pos.y,
            Mathf.Clamp(pos.z, LeftBottom.z + transform.localScale.z - Bottom, RightTop.z - transform.localScale.z - Top));
    }
}
