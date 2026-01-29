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
        BTime = BTime + Time.deltaTime;

        if (BTime == 5)
        {
            Destroy(gameObject);
            BTime = 0f;
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
