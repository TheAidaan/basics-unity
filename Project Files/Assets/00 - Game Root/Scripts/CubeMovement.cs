using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    const float MOVE_SPEED = 0.3f;
    Rigidbody _rb;
    Vector3 _movementDir;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movementDir.normalized * MOVE_SPEED; // move in the direction the player wants at a set speed

    }

    // Update is called once per frame
    void Update()
    {
        _movementDir = Vector2.zero; 

        if (Input.GetKey(KeyCode.W))
        {
            _movementDir.y += 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {

            _movementDir.x -= 1f;

        }
        if (Input.GetKey(KeyCode.S))
        {
            _movementDir.y -= 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _movementDir.x += 1f;
        }
    }
}
