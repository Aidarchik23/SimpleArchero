using GameManagement;
using PlayerCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (EnemyManager.Instance.GameOver)
            {
                SceneManager.LoadScene(1); // Next level
            }
        }
    }
}
