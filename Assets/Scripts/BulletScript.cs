using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float BTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BTime > 3f)
        {
            Destroy(gameObject);
            BTime = 0f;
        }
        else
        {
            BTime = BTime + Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
