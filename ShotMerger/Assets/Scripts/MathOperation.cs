using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Library
{
    public class MathOperation : MonoBehaviour
    {
        
        public static IEnumerator Addition(int getNumber, GameObject[] players, Transform position)
        {
            int number = 0;

            foreach (GameObject player in players)
            {

                if (number < getNumber)
                {
                    if (!player.activeInHierarchy)
                    {

                        player.transform.position = position.position;
                        player.SetActive(true);
                        number++;
                        
                    }
                    break;
                }
                else
                {
                    number = 0;
                    
                }
                yield return new WaitForSeconds(Player.coolDown);
            }
            Player.bulletCount += getNumber;

        }

        public static IEnumerator Multiply(int getNumber, GameObject[] players, Transform position)
        {

            int loopNumber = (Player.bulletCount * getNumber - Player.bulletCount);
            int number = 0;


            for (int i = 0; i < players.Length; i++)
            {

                if (number < loopNumber)
                {
                    if (!players[i].activeInHierarchy)
                    {
                        players[i].transform.position = position.position;
                        players[i].SetActive(true);
                        number++;
                        
                    }
                    
                }
                else
                {
                    number = 0;
                    break;
                }
                yield return new WaitForSeconds(Player.coolDown);
            }
            Player.bulletCount *= getNumber;
        }
    }
}

