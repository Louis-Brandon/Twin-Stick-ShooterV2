using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;


[RequireComponent (typeof(PlayerController))]

public class PlayerAttackController : MonoBehaviour
{
    PlayerController m_playerController;

    public GameObject m_bulletPrefab;

    public float m_attackSpeed;

    public enum m_FireMode
    {
        SemiAuto,
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

    void PlayerInput()
    {
        Vector3 aimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        aimPosition.z = 0;

        Vector3 aimDirection = aimPosition - transform.position;

        aimDirection = aimDirection.normalized;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (m_fireMode == m_FireMode.SemiAuto )
            {
                SpawnBullet(aimDirection);
            }
            if ((m_fireMode == m_FireMode.FullAuto) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                FullAutoBullet(m_attackSpeed, aimDirection);
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_fireMode = m_FireMode.SemiAuto;
            Debug.Log("1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_fireMode = m_FireMode.FullAuto;
            Debug.Log("2");
        }
    }
    IEnumerator FullAutoBullet(float m_attackSpeed,Vector3 aimDirection)
    {
        yield return new WaitForSecondsRealtime(m_attackSpeed);
        SpawnBullet(aimDirection);
    }
    void SpawnBullet(Vector3 aimDirection)
    {
        GameObject bullet = Instantiate(m_bulletPrefab, transform.position, Quaternion.identity);
        var bC = bullet.GetComponent<BulletController>();
        bC.m_direction = aimDirection;
        bC.m_damage = m_playerController.m_attackDamage;
    }
}
