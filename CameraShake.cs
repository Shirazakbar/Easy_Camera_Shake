using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //Camera Object
    public Transform cameraTransform;

    //Duration
    public float shakeDuration = 0f;

    //Change these to higher values fo more shake.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake()
    {
        if (cameraTransform == null)
        {
            cameraTransform = GetComponent<Transform>();
        }
    }

    void OnEnable()
    {
        originalPos = cameraTransform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            cameraTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            cameraTransform.localPosition = originalPos;
        }
    }

    //Use/Call this method to shake the camera.   (UI, Buttons, Events, etc)
    public void ShakeCamera()
    {
        ShakeCamera(0.5f, 0.3f);  //These are default values, however you can still pass your values when you call it in other scripts.
    }
    public void ShakeCamera(float duration, float amount)
    {
        shakeDuration = duration;
        shakeAmount = amount;
    }
}
