using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaifukuAnimation : MonoBehaviour
{

    public GameObject Image0;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    public GameObject Image5;
    public GameObject Image6;

    private GameObject ScoreObject;

    private bool Did = false;

    public AudioSource seSource;
    public AudioClip[] Hit;
    public AudioClip Fall;
    public AudioClip End;
    private int i;

    [SerializeField] GameObject pointText;

    void Start()
    {
        ScoreObject = GameObject.Find("GameObject");
        Did = false;
        seSource = this.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            if(Did == false)
            {
                //Time.timeScale = 0;
                seSource.PlayOneShot(Fall);
                seSource.PlayOneShot(End);
                ScoreObject.GetComponent<CountText>().OVER();

            }
            Destroy(this.gameObject,4);
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
            if (Did == false)
                {
                    bool IchigoBool = col.gameObject.GetComponent<Ichigo>().popopo;

                    if (IchigoBool == false)
                        {
                        col.gameObject.GetComponent<Ichigo>().Daifuku();
                        Vector3 posA = this.transform.position;
                        Vector3 posB = col.transform.position;
                        float dis = Vector3.Distance(posA, posB);
                        float point = 4.9f - dis;
                        SpawnPointEffect(this.transform.position, 100 * point * 0.5f);
                        ScoreObject.GetComponent<CountText>().AddPoint(100 * point * 0.5f);

                        if (dis <= 2.8f)
                        {
                            Invoke("GoodAnimation", 0);
                            SpawnGoodEffect(this.transform.position);
                            seSource.PlayOneShot(Hit[0]);
                        }
                        else
                        {
                            Invoke("Animation", 0);
                            SpawnBadEffect(this.transform.position);
                            seSource.PlayOneShot(Hit[1]);
                        }
                        //Debug.Log("‹——£ : " + dis);
                        //i = Random.Range(0, Hit.Length);

                        }
                    //Destroy(col.gameObject);
                }
            col.gameObject.GetComponent<Ichigo>().DaifukuAnime();
        }
    }

    void SpawnPointEffect(Vector2 position, float score)
    {
        GameObject effectObj = Instantiate(pointText, position, Quaternion.identity);
        PointEffects pointEffects = effectObj.GetComponent<PointEffects>();
        pointEffects.Show(score);
    }

    void SpawnGoodEffect(Vector2 position)
    {
        GameObject effectObj = Instantiate(pointText, position, Quaternion.identity);
        PointEffects pointEffects = effectObj.GetComponent<PointEffects>();
        pointEffects.Great();
    }

    void SpawnBadEffect(Vector2 position)
    {
        GameObject effectObj = Instantiate(pointText, position, Quaternion.identity);
        PointEffects pointEffects = effectObj.GetComponent<PointEffects>();
        pointEffects.Good();
    }

    // Update is called once per frame
    void Animation()
    {
        ScoreObject.GetComponent<CountText>().AddScore();
        Did = true; 

        Invoke("ZeroOne", 0);
        Invoke("OneTwo", 0.1F);
        Invoke("TwoThree", 0.2F);
        Invoke("ThreeFour", 0.3F);
        Invoke("FourFive", 0.4f);
        Invoke("FiveSix", 0.5F);
    }

    void GoodAnimation()
    {
        ScoreObject.GetComponent<CountText>().AddScore();
        Did = true;

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
