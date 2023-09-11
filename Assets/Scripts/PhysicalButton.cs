using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicalButton : MonoBehaviour
{
    [SerializeField]

    Transform pressButton;

    public UnityEvent OnPress;
    public UnityEvent OnRelease;

    AudioSource pressSound;
    GameObject pressorObject;
    bool isPressed = false;
     void Start()
    {
        pressSound= GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            OnPress?.Invoke();
            pressSound.Play();
            pressButton.localPosition = new Vector3(pressButton.localPosition.x, pressButton.localPosition.y - 0.02f, pressButton.localPosition.z);
            pressorObject = other.gameObject;
            isPressed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == pressorObject)
        {
            OnRelease?.Invoke();
           
           pressButton.localPosition = new Vector3(pressButton.localPosition.x, pressButton.localPosition.y +0.02f, pressButton.localPosition.z);
            isPressed=false;
        }
    }
}
