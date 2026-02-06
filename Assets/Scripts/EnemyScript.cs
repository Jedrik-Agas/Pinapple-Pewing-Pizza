using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Spawner= GameObject.FindAnyObjectByType<SpawnerScript>();

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
        RB.linearVelocity = transform.up * ESpeed;
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
            SpriteRenderer.color = new Color(1f, 0.64f, 0f, 1f);
            Health = Health -1;
            
            if (Health <= 0)
            {
                Destroy(gameObject);
                Spawner.SetEnemiesLeft(-1);
            }
              
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<PlayerControlScript>().SetHealth(Damage);
            Spawner.SetEnemiesLeft(-1);
        }
    }
}
