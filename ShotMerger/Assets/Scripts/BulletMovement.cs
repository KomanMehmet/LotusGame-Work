using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletMovement : MonoBehaviour
{

    float bulletMoveSpeed = 3f;
    bool isMove;





    private void FixedUpdate()
    {
        if (isMove)
        {
            transform.Translate(Vector3.forward * bulletMoveSpeed * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        isMove = true;
    }

    private void OnDisable()
    {
        isMove= false;
    }

}
