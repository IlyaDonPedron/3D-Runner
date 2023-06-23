using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    
    public GameObject animal;
    public float startDelay;
    public float repeatRate;
   
    void Start()
    {
        InvokeRepeating("SpawnObjects",startDelay,repeatRate);
    }

    void SpawnObjects()
    {
        float X = Random.Range(0.5f, 29.5f);
        GameObject clone = Instantiate(animal, new Vector3(X, 3f, 202.4f), transform.rotation);
    }
    
}
