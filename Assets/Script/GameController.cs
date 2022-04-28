using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject s_ObjEnemy;

    [SerializeField]
    GameObject s_ObjBomb;

    float s_spawnTime = 1.5f;

    float m_UpdateSpawnTime;
    //Bomb
    float m_TimeBomb = 2f;
    float m_UpdateTimeBomb;

    int m_Score = 0;

    bool m_isGameOver;

    UIManager m_UI;
    void Start()
    {
        m_UpdateSpawnTime = 0;
        m_UpdateTimeBomb = 1;
        m_UI = FindObjectOfType<UIManager>();
        m_UI.SetScoreText("Score: " + m_Score);
    }

    // Update is called once per frame
    void Update()
    {
      
        if (m_isGameOver)
        {
            s_spawnTime = 0;
            m_TimeBomb = 0;
            m_UI.ShowGameOverPane(true);
            return;
          
        }

        m_UpdateSpawnTime -= Time.deltaTime;
        m_UpdateTimeBomb -= Time.deltaTime;

        if (m_UpdateSpawnTime <= 0)
        {
            SpawnEnemy();
            m_UpdateSpawnTime = s_spawnTime;
        }

        if(m_UpdateTimeBomb <= 0)
        {
            SpawnBomb();
            m_UpdateTimeBomb = m_TimeBomb;
        }
    }

    public void SpawnEnemy()
    {
       
        float point = Random.Range(-7.6f, 7.5f);
        Vector2 spawnPoint = new Vector2(point, 6);

        if (s_ObjEnemy)
        {

            Instantiate(s_ObjEnemy, spawnPoint, Quaternion.identity);
        }
    }
    public void SpawnBomb()
    {
       
        float point = Random.Range(-7.5f, 7.5f);

        Vector2 spawnPoint = new Vector2(point, 6);

        if (s_ObjBomb)
        {
            Instantiate(s_ObjBomb, spawnPoint, Quaternion.identity);
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene("GamePlayer");
    }

    public void SetScore(int value)
    {
        m_Score = value;
    }

    public int GetScore()
    {
        return m_Score;
    }

    public void ScoreIncrement()
    {
        if (m_isGameOver)
            return;

        m_Score++;

        m_UI.SetScoreText("Score: " + m_Score);
    }

    public void SetGameOver(bool value)
    {
        m_isGameOver = value;
    }

    public bool GetGameOver()
    {
        return m_isGameOver;
    }
}
