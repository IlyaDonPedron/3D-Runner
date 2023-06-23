using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TimerGame : MonoBehaviour
{
    public Slider SliderGame;
    public float Timer;

    void Update()
    {
        Timer = Timer - 1 * Time.deltaTime;
        SliderGame.value = Timer;

        if (SliderGame.value == 0)
        {
            SceneManager.LoadScene(4);
        }
    }
}
