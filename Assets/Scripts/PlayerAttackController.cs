using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;


[RequireComponent (typeof(PlayerController))]

public class PlayerAttackController : MonoBehaviour
{
    PlayerController m_playerController;
    
    public GameObject m_bulletPrefab;

    public enum m_FireMode
    {
        Single,
        FullAuto
    }

    public m_FireMode m_fireMode;


    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_playerController = GetComponent<PlayerController> ();
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerInput();
    }
    bool m_singleShotFired = false;

    public float m_shotsPerSecond = 5f;
    float m_delayBetweenShotsPerSecond = 0;
    float m_fullAutoTimer = 0;

    void PlayerInput()
    {
        Vector3 aimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        aimPosition.z = 0;

        Vector3 aimDirection = aimPosition - transform.position;

        aimDirection = aimDirection.normalized;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (m_fireMode == m_FireMode.Single && !m_singleShotFired)
            {
                m_delayBetweenShotsPerSecond = 1 / m_shotsPerSecond;

                m_fullAutoTimer += Time.deltaTime;
                SpawnBullet(aimDirection);
                m_singleShotFired = true;

                
            }
            if (m_fireMode == m_FireMode.FullAuto)
            {
                m_delayBetweenShotsPerSecond = 1 / m_shotsPerSecond;

                m_fullAutoTimer += Time.deltaTime;

                if (m_fullAutoTimer >= m_delayBetweenShotsPerSecond) 
                {
                    m_fullAutoTimer = m_fullAutoTimer * 0.5f;
                    SpawnBullet(aimDirection);
                }

                //FireFullAuto(m_attackSpeed, aimDirection);
            }

        }
        //When mouse key is released - Lets reset our gun!
        else if (Input.GetKeyUp(KeyCode.Mouse0)) 
        {
            //false because we are resetting the bool for the next semi auto single shot
            m_singleShotFired = false;
            m_fullAutoTimer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_fireMode = m_FireMode.Single;
            Debug.Log("1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_fireMode = m_FireMode.FullAuto;
            Debug.Log("2");
        }
    }

    void SpawnBullet(Vector3 aimDirection)
    {
        GameObject bullet = Instantiate(m_bulletPrefab, transform.position, Quaternion.identity);
        var bC = bullet.GetComponent<BulletController>();
        bC.m_direction = aimDirection;
        bC.m_damage = m_playerController.m_attackDamage;
    }
}
