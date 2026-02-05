using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControlScript : MonoBehaviour
{

    private float MoveSpeed = 10f;
    private const float BaseFireRate = 0.8f;
    private float FireRate = BaseFireRate;
    public const int MaxHealth = 3;
    public int Health = MaxHealth;
    private Rigidbody2D RB;
    public WeaponScript Weapon;
    public HealthBarScript HealthBar;

    private Vector2 MoveDirection;
    private Vector2 MouseDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        HealthBar = GetComponentInChildren<HealthBarScript>();
        HealthBar.BarUpdate(Health);
    }

    // Update is called once per frame
    void Update()
    {
        RB.linearVelocity = MoveDirection * MoveSpeed;
        MouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition); 

        if (Input.GetMouseButton(0) && FireRate > 1f)
        {
            Weapon.Fire();
            FireRate = BaseFireRate;
        }
        else
        {
            FireRate = FireRate + Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Vector2 Aim = MouseDirection - RB.position;
        float Angle = Mathf.Atan2(Aim.y, Aim.x) * Mathf.Rad2Deg - 90f;
        RB.rotation = Angle;
    }

    public void OnMove(InputValue Value)
    {
        MoveDirection = Value.Get<Vector2>().normalized;
    }

    public void SetHealth(int amount)
    {
        Health += amount;
        HealthBar.BarUpdate(Health);

        if (Health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            gameObject.SetActive(false);
        }
    }

}
