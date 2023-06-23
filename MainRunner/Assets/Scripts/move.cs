using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class move : MonoBehaviour
{

    public float speed;
    public  float leftBorder=0;

    private void Start()
    {
        transform.Rotate(0,180,0);
    }
    void Update()
    {

        transform.position += (Vector3.forward * speed) * Time.deltaTime;
        Destroy();
    }

    void Destroy()
    {
        
        if (transform.position.z < leftBorder)
        {
            Destroy(gameObject);
            Debug.Log("Достигла точки");
        }
    }
}
