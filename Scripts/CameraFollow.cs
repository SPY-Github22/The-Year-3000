using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float damping;    
    private Vector3 velocity = Vector3.zero;
    private GameController GCont;
    private bool followPlayer;
    Vector3 position = new Vector3(19.7f, 19.7f, -10);
    Vector3 position2;
    

    private void Awake() {
        followPlayer = true;
    }
    
    private void Update() {
        GCont = gameObject.GetComponent<GameController>();

        if (GCont.release == true) {
            followPlayer = false;
            iTween.MoveTo(Camera.main.gameObject, position, 1.5f);
            Invoke("afterThat", 0.5f);
        }
    }

    void LateUpdate() {
        if (followPlayer == true) {
        Vector3 movePosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
        position2 = Camera.main.transform.position;
        }
    }

    private void afterThat() {
        iTween.MoveTo(Camera.main.gameObject, position2, 1);
        Invoke("afterNext", 1);
    }

    private void afterNext() {
        followPlayer = true;
    }
}
