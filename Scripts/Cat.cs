using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    public GameObject Image0;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    public GameObject Image5;
    public GameObject Image6;

    private GameObject ScoreObject;
    public AudioSource seSource;
    public AudioClip Fall;
    public AudioClip Eat;
    public AudioClip Voice;

    private GameObject Ichigo;


    // Start is called before the first frame update
    void Start()
    {
        ScoreObject = GameObject.Find("GameObject");
        seSource = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Floor")
        {
            Destroy(this.gameObject,4);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ichigo")
        {
            bool IchigoBool = col.gameObject.GetComponent<Ichigo>().popopo;
            if (IchigoBool == false)
            { 
                Invoke("Animation", 0);
                seSource.PlayOneShot(Eat);
                seSource.PlayOneShot(Voice);
                seSource.PlayOneShot(Fall);
                col.gameObject.GetComponent<Ichigo>().CatDestroy();         
                ScoreObject.GetComponent<CountText>().OVER();
            }

        }
    }

    void Animation()
    {
        Invoke("ZeroOne", 0);
        Invoke("OneTwo", 0.1F);
        Invoke("TwoThree", 0.2F);
        Invoke("ThreeFour", 0.3F);
        Invoke("FourFive", 0.4f);
        Invoke("FiveSix", 0.5F);
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

    void FiveSix()
    {
        Image5.SetActive(false);
        Image6.SetActive(true);
    }
}
