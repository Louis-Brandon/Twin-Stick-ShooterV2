using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Entity
{
    Vector2 m_directionInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void PlayerInput()
    {
       /* if (Input.GetKey(KeyCode.W))
        {
            m_directionInput = new Vector2(m_directionInput.x, 1);
            Debug.Log("w");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_directionInput = new Vector2(m_directionInput.x, -1);
            Debug.Log("S");
        }
        else
        {
            m_directionInput = new Vector2(m_directionInput.x, 0);
        }
        

        if (Input.GetKey(KeyCode.A))
        {
            m_directionInput = new Vector2(1, m_directionInput.y);
            Debug.Log("A");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_directionInput = new Vector2(-1, m_directionInput.y);
            Debug.Log("D");
        }
        else
        {
            m_directionInput = new Vector2(0, m_directionInput.y);
        }
       */


    }

    public void OnMove(InputValue value)
    {
        Vector2 rawInput = value.Get<Vector2>();

        m_directionInput = new Vector2(rawInput.x * -1, rawInput.y);
    }

    public override void OnDeath()
    {
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        //PlayerInput();

        MoveEntity( Vector2.ClampMagnitude(m_directionInput, 1));
    }
}
