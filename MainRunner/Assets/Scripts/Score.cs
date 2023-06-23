using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Text scoreText;
    public int Count;
    public AudioSource collectCoin;

    void Start()
    {
        Count = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            collectCoin.Play();
            Count++;
            scoreText.text="Score: "+ Count.ToString();
            other.gameObject.SetActive(false);
            
        }
    }
}
