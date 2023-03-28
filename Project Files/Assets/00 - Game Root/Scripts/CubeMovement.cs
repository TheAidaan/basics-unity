using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    const float MOVE_SPEED = 0.9f;

    Color32 _yellow = new Color32(176,169,0,255);
    Color32 _green = new Color32(15,186,0,255);
    Color32 _blue = new Color32(0,94,205,255);
    Color32 _purple = new Color32(152,0,205,255);

    Color32 _black = new Color32(38,38,38,255);


    Rigidbody _rb;
    Material _mat;
    Vector3 _movementDir;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
       _mat = GetComponent<Renderer>().material;
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movementDir.normalized * MOVE_SPEED; // move in the direction the player wants at a set speed

    }

    // Update is called once per frame
    void Update()
    {
        _movementDir = Vector2.zero;

        _mat.color = _black;

        if (Input.GetKey(KeyCode.W))
        {
            _movementDir.y += 1f;
            _mat.color = _yellow;

        }
        if (Input.GetKey(KeyCode.A))
        {

            _movementDir.x -= 1f;
            _mat.color = _green;


        }
        if (Input.GetKey(KeyCode.S))
        {
            _movementDir.y -= 1f;
            _mat.color = _blue;

        }
        if (Input.GetKey(KeyCode.D))
        {
            _movementDir.x += 1f;
            _mat.color = _purple;

        }
    }
}
