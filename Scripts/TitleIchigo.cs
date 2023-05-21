using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleIchigo : MonoBehaviour
{

    public GameObject Image0;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    public GameObject Image5;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Animation), 0, 0.8f);
    }

    public void Animation()
    {
        Invoke("ZeroOne", 0);
        Invoke("OneTwo", 0.1F);
        Invoke("TwoThree", 0.2F);
        Invoke("ThreeFour", 0.3F);
        Invoke("FourFive", 0.4f);
        Invoke("FiveZero", 0.5f);
    }

    void ZeroOne()
    {
        Image0.SetActive(false);
        Image1.SetActive(true);

    }

    void OneTwo()
    {
        Image1.SetActive(false);
        Image2.SetActive(true);
    }

    void TwoThree()
    {
        Image2.SetActive(false);
        Image3.SetActive(true);
    }

    void ThreeFour()
    {
        Image3.SetActive(false);
        Image4.SetActive(true);
    }

    void FourFive()
    {
        Image4.SetActive(false);
        Image5.SetActive(true);
    }

    void FiveZero()
    {
        Image5.SetActive(false);
        Image0.SetActive(true);
    }
}
