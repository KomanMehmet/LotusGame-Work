using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Library;


public class Player : MonoBehaviour
{
    public GameManager _gameManager;
    public CanvasManager _canvasManager;



    [Header("Player")]
    private Vector3 newPos = Vector3.zero;
    private bool localMovement;
    public Transform transMove;
    private float touchMoveSpeed = 0.1f;
    private float playerSpeed = 1.2f;


    public static float coolDown;


    //BulletCount'u kontrol edemediðim için mermi kontrolü saðlanamadý.
    public static int bulletCount = 1;
    public string operationType;



    private void Awake()
    {
        coolDown = 1 / bulletCount;
        _canvasManager.bullet_count.text = bulletCount.ToString();
    }


    private void FixedUpdate()
    {
        Touch touch;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {

                float newX = touch.deltaPosition.x * touchMoveSpeed * Time.deltaTime;
                newPos = localMovement ? transMove.localPosition : transMove.position;
                newPos.x += newX;
                newPos.x = Mathf.Clamp(newPos.x, -1.1f, 1.1f);

                if (localMovement)
                {
                    transMove.localPosition = newPos;
                }
                else
                {
                    transMove.position = newPos;
                }
            }
        }
        transform.Translate(-Vector3.forward * playerSpeed * Time.deltaTime);

        if (operationType == "")
        {
            operationType = "Multiple";
        }


        _gameManager.Create_Bullet(operationType, bulletCount);


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Multiple") || other.gameObject.CompareTag("Addition"))
        {
            
            int number = int.Parse(other.name);
            bulletCount = number;
            operationType = other.tag;

            coolDown = 1f / bulletCount;
            StackManager.instance.Stack_forward(other.transform);
            _canvasManager.bullet_count.text = bulletCount.ToString();
        }

        if (other.gameObject.CompareTag("LastPoint"))
        {
            playerSpeed = 1.9f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Area"))
        {
            _canvasManager.endGameUI.SetActive(true);
            playerSpeed = 0;
        }
    }
}
