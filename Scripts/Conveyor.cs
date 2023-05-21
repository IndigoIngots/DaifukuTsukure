using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    /// <summary>
    /// �x���g�R���x�A�̉ғ���
    /// </summary>
    public bool IsOn = false;

    /// <summary>
    /// �x���g�R���x�A�̐ݒ葬�x
    /// </summary>
    public float TargetDriveSpeed = 3.0f;

    /// <summary>
    /// ���݂̃x���g�R���x�A�̑��x
    /// </summary>
    public float CurrentSpeed { get { return _currentSpeed; } }

    /// <summary>
    /// �x���g�R���x�A�����̂𓮂�������
    /// </summary>
    public Vector2 DriveDirection = Vector2.left;

    /// <summary>
    /// �R���x�A�����̂������́i�����́j
    /// </summary>
    [SerializeField] private float _forcePower = 50f;

    private float _currentSpeed = 0;
    private List<Rigidbody2D> _rigidbodies = new List<Rigidbody2D>();

    void Start()
    {
        //�����͐��K�����Ă���
        DriveDirection = DriveDirection.normalized;
    }

    void FixedUpdate()
    {
        _currentSpeed = IsOn ? TargetDriveSpeed : 0;

        //���ł����I�u�W�F�N�g�͏�������
        _rigidbodies.RemoveAll(r => r == null);

        foreach (var r in _rigidbodies)
        {
            //���̂̈ړ����x�̃x���g�R���x�A�����̐������������o��
            var objectSpeed = Vector2.Dot(r.velocity, DriveDirection);

            //�ڕW�l�ȉ��Ȃ��������
            if (objectSpeed < Mathf.Abs(TargetDriveSpeed))
            {
                r.AddForce(DriveDirection * _forcePower, ForceMode2D.Force);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var rigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
        _rigidbodies.Add(rigidBody);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        var rigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
        _rigidbodies.Remove(rigidBody);
    }
}
