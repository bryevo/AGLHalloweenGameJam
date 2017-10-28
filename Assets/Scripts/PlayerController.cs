using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Public Information
    public float moveSpeed;

    public float jumpSpeed;

    //Local Variables
    float _playerSpeed;
    bool _facingRight;
    Animator _anim;
    Rigidbody2D _playerRigidBody;


    void Start()
    {
        _anim = GetComponent<Animator>();
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _facingRight = true;
        _playerSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(_playerSpeed);
        FlipPlayer();
        
        //Left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _playerSpeed = -moveSpeed;
        }

        //Right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _playerSpeed = moveSpeed;
        }
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            _playerSpeed = 0;
        }
    }

    void MovePlayer(float playerSpeed)
    {
        if (playerSpeed != 0f)
        {
            _anim.SetInteger("State", 1);
        }
        else
        {
            _anim.SetInteger("State", 0);

        }
        _playerRigidBody.velocity = new Vector3(_playerSpeed, _playerRigidBody.angularVelocity, 0);
    }

    void FlipPlayer()
    {
        if (_playerSpeed < 0 && !_facingRight || _playerSpeed > 0 && _facingRight)
        {
            _facingRight = !_facingRight;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }
}