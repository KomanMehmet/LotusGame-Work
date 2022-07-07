using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BulletCollision : MonoBehaviour
{
    public GameManager _gameManager;

    public TMP_Text targetTexts;
    
    private int targetTextCounter;

    private void Awake()
    {

        targetTextCounter = int.Parse(targetTexts.text);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {

            other.gameObject.SetActive(false);
            targetTextCounter--;
            targetTexts.text = targetTextCounter.ToString();

            
            //Debug.Log(targetTextCounter);

            if (targetTextCounter == 0)
            {
                gameObject.SetActive(false);
            }

        }

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            _gameManager.gameOverUI.SetActive(true);

            

        }

        if (other.gameObject.CompareTag("Addition") || other.gameObject.CompareTag("Multiple"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
