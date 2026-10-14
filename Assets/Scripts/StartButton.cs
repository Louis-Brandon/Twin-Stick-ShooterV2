using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    void Start()
    {

    }

    public void PressStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
