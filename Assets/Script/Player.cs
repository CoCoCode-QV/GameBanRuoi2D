using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    GameObject m_bullet;


    [SerializeField]
    GameObject m_EffectsBomb;

    [SerializeField]
    Transform m_shootingPoint;

    GameController m_gc;

    [SerializeField]
    AudioSource m_audios;


    [SerializeField]
    AudioClip m_hitSoundBomb;

    [SerializeField]
    AudioClip m_shooting;
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gc.GetGameOver())
            return;
        
        float xDirection = Input.GetAxisRaw("Horizontal");

        if ((xDirection < 0 && transform.position.x <= -8.9f) || (xDirection > 0 && transform.position.x >= 5.8f))
            return;

        transform.position += Vector3.right * moveSpeed * xDirection * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();

        }
    }
    public void Shoot()
    {
        if (m_bullet && m_shootingPoint)
        {
            if(m_audios && m_shooting)
            {
                m_audios.PlayOneShot(m_shooting);
            }    
            Instantiate(m_bullet, m_shootingPoint.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            m_gc.SetGameOver(true);

            Destroy(collision.gameObject);

        }else if (collision.CompareTag("Bomb"))
        {
            Vector3 SpawnHere = gameObject.transform.position;

            if (m_EffectsBomb)
                Instantiate(m_EffectsBomb, SpawnHere, Quaternion.identity);

            m_gc.SetGameOver(true);

            if (m_audios && m_hitSoundBomb)
            {
                m_audios.PlayOneShot(m_hitSoundBomb);
            }

            Destroy(gameObject);

            Destroy(collision.gameObject);

        }
    }
}
