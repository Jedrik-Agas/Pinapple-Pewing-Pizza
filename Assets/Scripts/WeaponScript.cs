using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform FirePoint;
    public float BulletForce = 20f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        GameObject Bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.up * BulletForce, ForceMode2D.Impulse);
    }
}
