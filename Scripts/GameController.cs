using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameObject Player;
    public GameObject First;
    public GameObject Second;
    public GameObject Third;
    public GameObject WonM;
    public GameObject FirstStage;
    public GameObject StartTalk;
    public GameObject WonTxt;
    private PlayerMove AyyMan;
    private Win YoMan;
    private bool entAlr;
    public bool release;

    // Start is called before the first frame update
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        AyyMan = Player.GetComponent<PlayerMove>();
        YoMan = Player.GetComponent<Win>();
        entAlr = false;
        release = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (AyyMan.started == true && entAlr == false) {
            entAlr = true;
            AyyMan.canMove = false;
            if (StartTalk.activeSelf == false) {
                FirstStage.SetActive(false);
                StartTalk.SetActive(true);
                First.SetActive(true);
                Invoke("secondOne", 5); 
            }
        }

        if (YoMan.won) { //Or can create new bool here and change only it but not needed currently
            YoMan.won = false;
            FirstStage.SetActive(false);
            WonM.SetActive(true);
            Invoke("teleport", 4f);
        }
    }

    private void secondOne() {
        First.SetActive(false);
        Second.SetActive(true);
        Invoke("thirdOne", 5);
    }

    private void thirdOne() {
        Second.SetActive(false);
        Third.SetActive(true);
        release = true;
        enterMoveCamera();
        Invoke("thirdTwo", 5);
    }

    private void thirdTwo() {
        Third.SetActive(false);
        StartTalk.SetActive(false);
        FirstStage.SetActive(true);
        AyyMan.canMove = true;
        AyyMan.started = false;
    }

    //Try Lambda over here instead of above

    private void enterMoveCamera() {
        Invoke("eMCam", 4);
    }

    private void eMCam() {
        release = false;
    }

    private void teleport() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
