using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D RB;
    private float ESpeed = 5f;
    private float RotateSpeed = 1f;
    public int Health = 2;
    public int Damage = -1;
    public Transform Target;
    public SpriteRenderer SpriteRenderer;
    public SpawnerScript Spawner;
    private HitFlashScript HitFlash;
    public ScoreScript Score;
    private ParticleSystem Particle;
    private AudioSource AudioSource;
    private Coroutine ExplosionCorutine;
    private bool CanDamage = true;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Particle = GetComponent<ParticleSystem>();
        HitFlash = GetComponent<HitFlashScript>();
        AudioSource = GetComponent<AudioSource>();
        Score = GameObject.FindGameObjectWithTag("UI").GetComponent<ScoreScript>();
        Spawner = GameObject.FindAnyObjectByType<SpawnerScript>();

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            Target = GameObject.FindGameObjectWithTag("Player").transform;
        }

    }
    void Update()
    {
        TurnToTarget();
    }

    private void FixedUpdate()
    {
        if (CanDamage == true)
        {
            RB.linearVelocity = transform.up * ESpeed;
        }
    }

    private void TurnToTarget()
    {
        Vector2 TargetDirection = Target.position - transform.position;
        float Angle = Mathf.Atan2(TargetDirection.y, TargetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion TargetRotation = Quaternion.Euler(new Vector3(0, 0, Angle));
        transform.rotation = Quaternion.Slerp(transform.localRotation, TargetRotation, RotateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            HitFlash.Flash();
            Health = Health -1;
            if (Health <= 0)
            {
                CanDamage = false;
                ExplosionCorutine = StartCoroutine(PlayExplosion());
            }
              
        }
        if (other.gameObject.CompareTag("Player"))
        {
            if (CanDamage == true)
            {
                AudioSource.Play();
                Destroy(gameObject);
                other.gameObject.GetComponent<PlayerControlScript>().SetHealth(Damage);
                Spawner.SetEnemiesLeft(-1);
            }
        }
    }

    private IEnumerator PlayExplosion()
    {
        Particle.Play();
        SpriteRenderer.enabled = false;
        AudioSource.Play();
        yield return new WaitForSeconds(Particle.main.duration);
        Score.AddScore(1);
        Destroy(gameObject);
        Spawner.SetEnemiesLeft(-1);
    }

}