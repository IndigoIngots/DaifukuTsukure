using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointEffects : MonoBehaviour
{
    //[SerializeField] Text text;
    [SerializeField] GameObject Perfect;
    [SerializeField] GameObject GoodObj;

    public void Show(float score)
    {
        //text.text = score.ToString();
        StartCoroutine(MoveUp());
    }

    public void Great()
    {
        //text.text = "PERFECT";
        Perfect.SetActive(true);
        StartCoroutine(MoveGreat());
    }

    public void Good()
    {
        //text.text = "GOOD";
        GoodObj.SetActive(true);
        StartCoroutine(MoveGreat());
    }

    IEnumerator MoveUp()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(-0.05f, 0.06f, 0);
        }
        Destroy(gameObject, 0.2f);
    }

    IEnumerator MoveGreat()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(-0.05f, 0.06f, 0);
        }
        Destroy(gameObject, 0.2f);
    }



}
