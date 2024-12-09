using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

   public GameObject menuUI;
   public GameObject gamePlayUI;

   public GameObject spawner;
     public static GameManager instance;
    public bool gameStarted = false;

    Vector3 originalCamPos;

    public GameObject player;

    public GameObject backgroundParticle;


    int lives = 2;
    int score = 0;

    public Text scoreText;
    public Text livesText;
     private void Awake()
     {
        instance = this;
     }
      
      private void Start()
      {
         originalCamPos = Camera.main.transform.position;
      }
    public void StartGame()
    {
       gameStarted = true; 

       menuUI.SetActive(false);
       gamePlayUI.SetActive(true);
       spawner.SetActive(true);
       backgroundParticle.SetActive(true);
    }

    public void GameOver()
    {
          player.SetActive(false);
           
           Invoke("ReloadLevel", 1.5f);
    }

    public void ReloadLevel()
    {
       SceneManager.LoadScene("Game");   
    }

      public void UpdateLives()
      {
          if(lives <= 0)
          {
             GameOver();

          }
          else{
            lives--;
            livesText.text =" Lives : " + lives;
            print("lives : " + lives);
          }
      }
        public void UpdateScore()
        {
           score++;
           scoreText.text = "Score : " +score;
           print("Score:" +score);
        }

        public void ExitGame()
        {
         Application.Quit();
        }

        public void Shake()
        {
         StartCoroutine("CameraShake");
        }
        
        IEnumerator CameraShake()
        {
         for(int i  = 0; i < 5; i++)
         {
            Vector2 randomPos = Random.insideUnitCircle * 0.5f;

            Camera.main.transform.position = new Vector3(randomPos.x, randomPos.y, originalCamPos.z);
           
            yield return null;
        
         }

         Camera.main.transform.position = originalCamPos;
        }
}
