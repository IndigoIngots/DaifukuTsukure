using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ichigo : MonoBehaviour
{
    public GameObject Image1;
    public GameObject Image2;

    public bool popopo = false;

    public AudioSource seSource;
    public AudioClip Fall;

    void Start()
    {
        seSource = this.GetComponent<AudioSource>();
        seSource.PlayOneShot(Fall);
    }
      
    public void Daifuku()
    {
        if (popopo == false)
        {
            Destroy(this.gameObject);
        }
        Image1.SetActive(false);
        Image2.SetActive(true);
        popopo = true;
    }

    public void DaifukuAnime()
    {
        Image1.SetActive(false);
        Image2.SetActive(true);
        popopo = true;
    }

    public void CatDestroy()
    {
        if (popopo == false)
        { 
            Destroy(this.gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {

            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Floor")
        {
            Destroy(this.gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Conveyor")
        {
            Image1.SetActive(false);
            Image2.SetActive(true);
            popopo = true;
        }

        if (col.gameObject.tag == "Ichigo")
        {
            popopo = true;
            Image1.SetActive(false);
            Image2.SetActive(true);
        }
    }

}
