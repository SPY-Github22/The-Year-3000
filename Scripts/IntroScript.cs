using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public GameObject TitleO;
    public GameObject FirstO;
    public GameObject SecondO;
    public GameObject ThirdO;
    public GameObject FourthO;
    private GameObject current;

    private void Awake()
    {
        current = TitleO;
        Invoke("Deactivate", 3);

        Invoke("Deactivate1", 6);

        Invoke("Deactivate2", 10);

        Invoke("Deactivate3", 14);

        Invoke("Deactivate4", 18);
    }

    private void Deactivate() {
        current.SetActive(false);
        current = FirstO;
    }
    
    private void Deactivate1() {
        current.SetActive(false);
        current = SecondO;
    }

    private void Deactivate2() {
        current.SetActive(false);
        current = ThirdO;
    }

    private void Deactivate3() {
        current.SetActive(false);
        current = FourthO;
    }

    private void Deactivate4() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
