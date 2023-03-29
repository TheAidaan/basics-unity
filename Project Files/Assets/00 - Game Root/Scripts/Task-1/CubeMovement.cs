using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    float _moveSpeed= 1f;

    Color32 _yellow = new Color32(176,169,0,255);
    Color32 _green = new Color32(15,186,0,255);
    Color32 _blue = new Color32(0,94,205,255);
    Color32 _purple = new Color32(152,0,205,255);

    Color32 _black = new Color32(38,38,38,255);


    Rigidbody _rb;
    Renderer _rend;
    Material _mat;
    Vector3 _movementDir;

    DisplayVelocity _displayVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rend = GetComponent<Renderer>();
        _mat = _rend.material;

        _displayVelocity = FindObjectOfType<DisplayVelocity>();
    }

    private void FixedUpdate()
    {
        _moveSpeed = Mathf.Max(_moveSpeed, 0f);
        _rb.velocity = _movementDir.normalized * _moveSpeed; // move in the direction the player wants at a set speed

        ScreenWrap();

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
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _moveSpeed-=.5f;
            _displayVelocity.UpdateText(_moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _moveSpeed+=.5f;
            _displayVelocity.UpdateText(_moveSpeed);


        }
    }

    void ScreenWrap()
    {
        Vector3 newPos = transform.position;

        if (!_rend.isVisible)
        {
            // Get the position of the camera in world space
            Vector3 camPos = Camera.main.transform.position;

            // Get the width and height of the screen
            float camHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
            float camHalfHeight = Camera.main.orthographicSize;

            // Wrap the position of the game object around the screen
            if (newPos.y > camPos.y + camHalfHeight)
            {
                newPos.y = camPos.y - camHalfHeight;
            }
            else if (newPos.y < camPos.y - camHalfHeight)
            {
                newPos.y = camPos.y + camHalfHeight;
            }

            if (newPos.x > camPos.x + camHalfWidth)
            {
                newPos.x = camPos.x - camHalfWidth;
            }
            else if (newPos.x < camPos.x - camHalfWidth)
            {
                newPos.x = camPos.x + camHalfWidth;
            }
        }

        transform.position = newPos;
    }
}

