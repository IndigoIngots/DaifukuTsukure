using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using NCMB;

public enum GameState
{
    Game,
    Over,
}

public class CountText : MonoBehaviour
{
    GameState state = GameState.Over;

    public GameObject quantityObj; //�X�R�A�e�L�X�g���i�[����Ă����̃I�u�W�F�N�g

    public int quantity = 0; //�X�R�A���̂̐��l
    public Text quantityText; //�X�R�A�̃e�L�X�g�I�u�W�F�N�g


    public GameObject scoreObj; //�X�R�A�e�L�X�g���i�[����Ă����̃I�u�W�F�N�g

    public float score = 0; //�X�R�A���̂̐��l
    public Text scoreText; //�X�R�A�̃e�L�X�g�I�u�W�F�N�g



    public GameObject overText; //GameOver�e�L�X�g�̊i�[����Ă����̃I�u�W�F�N�g

    public Text HighQuantityText; //�n�C�X�R�A��\������Text
    private int highQuantity; //�n�C�X�R�A�̐��l

    public Text HighScoreText; //�n�C�X�R�A��\������Text
    private int highscore; //�n�C�X�R�A�̐��l

    public Text mochimochiCountText;
    private int mochimochiCount;


    public GameObject STARTPanel; //�X�^�[�g��ʂ̃p�l��

    public int posX;
    public int posYIchigo;

    public GameObject[] Daifuku;
    public GameObject Ichigo;

    public GameObject conveyor;

    private int number;

    private int counter;

    [SerializeField] AudioSource seSource;
    public AudioClip Pon;


    void Start()
    {
        Application.targetFrameRate = 60;

        state = GameState.Over;
        highQuantity = PlayerPrefs.GetInt("HighScore", 0);
        Time.timeScale = 1.2F;

        STARTPanel.SetActive(true);
        conveyor.SetActive(false);


        InvokeRepeating(nameof(CreateRandom), 2.0f, 1.0f);
        //number = Random.Range(0, Daifuku.Length);
        counter = 300;
        overText.SetActive(false);

        mochimochiCount = PlayerPrefs.GetInt("MochiCount", 0);
        mochimochiCountText.text = ":" +mochimochiCount.ToString("D7");
        //NCMBObject testClass = new NCMBObject("TestClass");
    }


    public void PushStart()
    {
        state = GameState.Game;

        STARTPanel.SetActive(false);
        conveyor.SetActive(true);
        quantityObj.SetActive(true);
        scoreObj.SetActive(true);

        seSource.PlayOneShot(Pon);
    }

    public void PushGoTitle()
    {
        quantity = 0;
        quantityObj.SetActive(false);
        score = 0;
        scoreObj.SetActive(false);
        overText.SetActive(false);
        STARTPanel.SetActive(true);

        PlayerPrefs.SetInt("MochiCount", mochimochiCount);
        mochimochiCountText.text = ":" + mochimochiCount.ToString("D7");

        seSource.PlayOneShot(Pon);
    }

    public void PushRESTART()
    {
        state = GameState.Game;

        quantity = 0;
        score = 0;
        conveyor.SetActive(true);
        overText.SetActive(false);

        seSource.PlayOneShot(Pon);
    }

    public void OVER() 
    {
        state = GameState.Over;

        overText.SetActive(true);

        Time.timeScale = 1.2F;
        seSource.pitch = 1.0F;
        conveyor.SetActive(false);

        if (quantity > highQuantity)
        {

            highQuantity = quantity;
            //�n�C�X�R�A�X�V

            PlayerPrefs.SetInt("HighScore", highQuantity);
            //�n�C�X�R�A��ۑ�


        }
            //�n�C�X�R�A��\��
            HighQuantityText.text = "�͂��������@" + "<color=#FF2C2C>" + highQuantity.ToString() + "��"  + "</color>";

            mochimochiCount = mochimochiCount + quantity;
            PlayerPrefs.SetInt("MochiCount", highscore);
    }

    public void Rank()
    { 
            //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (quantity);
    }


    public void Tweet()
    {
        //naichilab.UnityRoomTweet.Tweet("daifukutukure", "�����������ӂ���" + quantity + "��������I score:" + score , "unityroom", "�����ӂ�����");
    }

    void CreateRandom()
    {
        number = Random.Range(0, Daifuku.Length);
        Vector2 newPos = this.transform.position;
        newPos.x = posX;
        GameObject Da = Instantiate(Daifuku[number]) as GameObject;
        Da.transform.position = newPos;
    }

    void CreateIchigo()
    {
        counter = 0;
        Vector2 newPosIchi = this.transform.position;
        newPosIchi.y = posYIchigo;
        GameObject Ichi = Instantiate(Ichigo) as GameObject;
        Ichi.transform.position = newPosIchi;
    }

    public void AddScore()
    {
        quantity++;

    }

    public void AddPoint(float point)
    {
        score = score + point;
    }

    void FixedUpdate()
    {
        counter++;
    }

    void Update()
    {
        if (state == GameState.Game)
        { 
            //counter++;
            if (Input.GetMouseButtonDown(0))
            {
                if (counter >= 15)
                {
                    Invoke("CreateIchigo", 0);
                }
            }
        }

        quantityText.text = "�����������ӂ� " + quantity.ToString() + "��";
        scoreText.text = "�Ƃ��Ă�:" + score.ToString("f2");

        if (quantity < 5)
        {
            Time.timeScale = 1.2F;
            seSource.pitch = 1f;
        }

        else if (quantity == 5)
        {
            Time.timeScale = 1.35F;
            seSource.pitch = 1.025f;
        }

        else if (quantity == 10)
        {
            Time.timeScale = 1.5F;
            seSource.pitch = 1.05f;
        }

        else if (quantity == 20)
        {
            Time.timeScale = 1.65F;
            seSource.pitch = 1.075f;
        }

        else if (quantity == 35)
        {
            Time.timeScale = 1.8F;
            seSource.pitch = 1.1f;
        }

        else if (quantity == 55)
        {
            Time.timeScale = 1.95F;
            seSource.pitch = 1.125f;
        }

        else if (quantity == 80)
        {
            Time.timeScale = 2.1F;
            seSource.pitch = 1.125f;
        }

        else if (quantity == 110)
        {
            Time.timeScale = 2.25F;
            seSource.pitch = 1.15f;
        }

        else if (quantity == 145)
        {
            Time.timeScale = 2.4F;
            seSource.pitch = 1.175f;
        }

        else if (quantity == 185)
        {
            Time.timeScale = 2.55F;
            seSource.pitch = 1.2f;
        }

        else if (quantity == 230)
        {
            Time.timeScale = 2.7F;
            seSource.pitch = 1.35f;
        }

    }

}
