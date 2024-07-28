using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private int _verticalAxis;
    private int _horizontalAxis;
    private Rigidbody _rigidbody;

    private void Start() => _rigidbody = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        ReadInput();
        Move();
    }

    private void ReadInput()
    {
        _horizontalAxis = 0;
        _verticalAxis = 0;
        if (Input.GetKey(KeyCode.A))
        {
            _horizontalAxis = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _horizontalAxis = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            _verticalAxis = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _verticalAxis = -1;
        }
    }

    private void Move()
    {
        Vector3 movement = new Vector3(_horizontalAxis, 0, _verticalAxis).normalized * _speed;
        _rigidbody.velocity = movement;
    }
}
