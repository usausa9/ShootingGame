using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �q�I�u�W�F�̃T�C�Y������
    private float Left, Right, Top, Bottom;
    // �J�������猩����ʍ���,�E��̍��W
    Vector3 LeftBottom;
    Vector3 RightTop;

    // Start is called before the first frame update
    void Start()
    {
        // �q�I�u�W�F�N�g�̐��������[�v�������s��
        foreach (Transform child in gameObject.transform)
        {
            // �q�I�u�W�F�̒��ň�ԉE�̈ʒu�Ȃ�
            if (child.localPosition.x >= Right)
            {
                // �q�I�u�W�F�̃��[�J�����W���E�[�p�̕ϐ��ɑ������
                Right = child.transform.localPosition.x;
            }
            // �q�I�u�W�F�̒��ň�ԍ��̈ʒu�Ȃ�
            if (child.localPosition.x <= Left)
            {
                // �q�I�u�W�F�̃��[�J�����W���E�[�p�̕ϐ��ɑ������
                Left = child.transform.localPosition.x;
            }
            // �q�I�u�W�F�̒��ň�ԏ�̈ʒu�Ȃ�
            if (child.localPosition.x >= Top)
            {
                // �q�I�u�W�F�̃��[�J�����W���E�[�p�̕ϐ��ɑ������
                Top = child.transform.localPosition.z;
            }
            // �q�I�u�W�F�̒��ň�ԉ��̈ʒu�Ȃ�
            if (child.localPosition.x <= Bottom)
            {
                // �q�I�u�W�F�̃��[�J�����W���E�[�p�̕ϐ��ɑ������
                Bottom = child.transform.localPosition.z;
            }
        }

        // �J�����ƃv���C���[�̋����𑪂�
        var distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        // �X�N���[����ʂ̈ʒu��ݒ�
        LeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));
    }

    // Update is called once per frame
    void Update()
    {
        
        // �v���C���[�̃��[���h���W���擾
        Vector3 pos = transform.position;

        // �L�[�����͂��ꂽ�Ƃ�
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
