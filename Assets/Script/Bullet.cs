using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D m_rb;
    [SerializeField]
    float m_speed;
    [SerializeField]
    float TimetoDestroy;
    GameController m_gc;

    [SerializeField]
    GameObject m_Effects;

    [SerializeField]
    GameObject m_EffectsBomb;

    AudioSource m_audios;

    [SerializeField]
    AudioClip m_hitSound;

    [SerializeField]
    AudioClip m_hitSoundBomb;
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();

        m_rb = GetComponent<Rigidbody2D>();

        Destroy(gameObject, TimetoDestroy);

        m_audios = FindObjectOfType<AudioSource>();

    }


    void Update()
    {
        m_rb.velocity = Vector2.up * m_speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Vector3 SpawnHere = gameObject.transform.position;

            Instantiate(m_Effects, SpawnHere, Quaternion.identity);
          
            if(m_audios && m_hitSound)
            {
                m_audios.PlayOneShot(m_hitSound);
            }

            m_gc.ScoreIncrement();

            Destroy(gameObject);

            Destroy(collision.gameObject);

        }else if (collision.CompareTag("Bomb"))
        {
            Vector3 SpawnHere = gameObject.transform.position;

            Instantiate(m_EffectsBomb, SpawnHere, Quaternion.identity);

            if (m_audios && m_hitSoundBomb)
            {
                m_audios.PlayOneShot(m_hitSoundBomb);
            }

            Destroy(gameObject);

            Destroy(collision.gameObject);
        }
    }

}
