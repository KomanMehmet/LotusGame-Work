using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Library;

public class GameManager : MonoBehaviour
{


    public Transform bulletSpawnPoint;
    public GameObject[] players;
    public GameObject gameOverUI;


    private void Update()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].transform.position.z - bulletSpawnPoint.transform.position.z > 7f)
            {
                players[i].SetActive(false);
                
            }
        }
    }


    public void Create_Bullet(string operationType, int getNumber)
    {
        switch (operationType)
        {
            case "Multiple":
                StartCoroutine(MathOperation.Multiply(getNumber, players, bulletSpawnPoint));
                break;

            case "Addition":
                StartCoroutine(MathOperation.Addition(getNumber, players, bulletSpawnPoint));
                break;
        }
    }


    public void Restart_Game()
    {
        SceneManager.LoadScene(0);
    }
}
