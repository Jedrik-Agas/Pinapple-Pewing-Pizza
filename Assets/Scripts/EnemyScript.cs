using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D RB;
    private float ESpeed = 5f;
    private float RotateSpeed = 1f;
    public Transform Target;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();

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
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
