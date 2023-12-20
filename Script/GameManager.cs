using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverText;
    public Text scoreText;
    public Text TimeText;
    public Text BestText;
    public Button button;
   
    public GameObject Spawn;
    public RaycastHit hit; // Enemy에 충돌했을 때 정보를 가져옴

    public bool isGameOver = false;
    private float gameTime ; 
    
    public int score = 0;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameTime = 60f;
    }
    private void Update()
    {

        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
            TimeText.text = "Time : " + (int)gameTime;
        }
        
    

        else
        {
           EndGame();
        }
    }

    public void Addscore(int addscore)
    {
        score += addscore;
        scoreText.text = "Score : " + score ;

    }

    private void EndGame()
    {
        gameOverText.SetActive(true) ;
        BestText.text = "Score : " + score;
        isGameOver = true ;
        button.enabled = false ;
        scoreText.enabled = false ;
        Spawn.SetActive(false); 
    }
}
