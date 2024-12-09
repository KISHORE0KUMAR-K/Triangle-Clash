using UnityEngine;
using UnityEngine.SceneManagement;
public class Playercontroller : MonoBehaviour
{

    public GameObject particle;
    float playerYpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerYpos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

      if(GameManager.instance.gameStarted)
      {
             if( !particle.activeInHierarchy)
             {        
             particle.SetActive(true);
             }
             if(Input.GetMouseButtonDown(0))
      {
               PositionSwitch();
      }   

      }
      

    }

    void PositionSwitch()
    {
     playerYpos = -playerYpos;

         transform.position = new Vector3(transform.position.x,playerYpos,transform.position.z);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.tag == "Obstacle")
      {
        // SceneManager.LoadScene("Game");

        //GameManager.instance.GameOver();

        GameManager.instance.UpdateLives();
        GameManager.instance.Shake();
      }
    }
}
