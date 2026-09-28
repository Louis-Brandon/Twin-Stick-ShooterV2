using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector2 m_direction;

    public float m_damage = 0f;
    public float m_speed;
    public float m_lifetime = 5f;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
      MoveBullet();
    }




    private void OnEnable()
    {
        StartCoroutine(DestroyBullet());
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSecondsRealtime(m_lifetime);
        Destroy(gameObject);
    }

    void MoveBullet()
    {
        transform.position += new Vector3(m_direction.x, m_direction.y) * m_speed * Time.deltaTime;
    }

}
