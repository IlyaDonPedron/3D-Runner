using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.position+=(Vector3.right*speed)*Time.deltaTime;
        transform.Rotate(0,3,0);

        if (transform.position.x >= 29.7f)
        {
            speed = -speed;
        }
        if (transform.position.x <= 0.2f)
        {
            speed= -speed;
        }
    }
}
