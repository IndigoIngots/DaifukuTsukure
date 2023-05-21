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

    public GameObject quantityObj; //スコアテキストが格納されてある空のオブジェクト

    public int quantity = 0; //スコア自体の数値
    public Text quantityText; //スコアのテキストオブジェクト


    public GameObject scoreObj; //スコアテキストが格納されてある空のオブジェクト

    public float score = 0; //スコア自体の数値
    public Text scoreText; //スコアのテキストオブジェクト



    public GameObject overText; //GameOverテキストの格納されている空のオブジェクト

    public Text HighQuantityText; //ハイスコアを表示するText
    private int highQuantity; //ハイスコアの数値

    public Text HighScoreText; //ハイスコアを表示するText
    private int highscore; //ハイスコアの数値

    public Text mochimochiCountText;
    private int mochimochiCount;


    public GameObject STARTPanel; //スタート画面のパネル

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
            //ハイスコア更新

            PlayerPrefs.SetInt("HighScore", highQuantity);
            //ハイスコアを保存


        }
            //ハイスコアを表示
            HighQuantityText.text = "はいすこあ　" + "<color=#FF2C2C>" + highQuantity.ToString() + "こ"  + "</color>";

            mochimochiCount = mochimochiCount + quantity;
            PlayerPrefs.SetInt("MochiCount", highscore);
    }

    public void Rank()
    { 
            //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (quantity);
    }


    public void Tweet()
    {
        //naichilab.UnityRoomTweet.Tweet("daifukutukure", "いちごだいふくを" + quantity + "個つくったよ！ score:" + score , "unityroom", "だいふくつくれ");
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

        quantityText.text = "いちごだいふく " + quantity.ToString() + "こ";
        scoreText.text = "とくてん:" + score.ToString("f2");

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
