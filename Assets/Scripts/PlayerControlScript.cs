using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControlScript : MonoBehaviour
{

    private float MoveSpeed = 10f;
    private const float BaseFireRate = 0.85f;
    private float FireRate = BaseFireRate;
    public const int MaxHealth = 3;
    public int Health = MaxHealth;
    private Rigidbody2D RB;
    private ParticleSystem Particle;
    public SpriteRenderer SpriteRenderer;
    public WeaponScript Weapon;
    public HealthBarScript HealthBar;
    private HitFlashScript HitFlash;
    private Coroutine ExplosionCorutine;
    private bool CanPlay= true;

    [SerializeField] private AudioSource AudioSource1;
    [SerializeField] private AudioSource AudioSource2;

    private Vector2 MoveDirection;
    private Vector2 MouseDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Particle = GetComponent<ParticleSystem>();
        HealthBar = GetComponentInChildren<HealthBarScript>();
        HitFlash = GetComponent<HitFlashScript>();
        HealthBar.BarUpdate(Health);
    }

    // Update is called once per frame
    void Update()
    {

        if(CanPlay == true)
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

    }

    private void FixedUpdate()
    {
        Vector2 Aim = MouseDirection - RB.position;
        float Angle = Mathf.Atan2(Aim.y, Aim.x) * Mathf.Rad2Deg - 90f;
        RB.rotation = Angle;
    }

    public void OnMove(InputValue Value)
    {
        if (CanPlay == true)
        {
            MoveDirection = Value.Get<Vector2>().normalized;
        }
    }

    public void SetHealth(int amount)
    {
        HitFlash.Flash();
        AudioSource2.Play();
        Health += amount;
        HealthBar.BarUpdate(Health);

        if (Health <= 0)
        {
            CanPlay = false;
            ExplosionCorutine = StartCoroutine(PlayExplosion());
        }
    }

    private IEnumerator PlayExplosion()
    {
        Particle.Play();
        SpriteRenderer.enabled = false;
        AudioSource1.Play();
        yield return new WaitForSeconds(Particle.main.duration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
