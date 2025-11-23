using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float mouseSensitivityY = 100.0f;
    private float xRotation = 0f;

    void Update()
    {
        // SADECE DÝKEY FARE HAREKETÝ (AÞAÐI/YUKARI BAKMA)
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Bu script kameranýn üzerinde olduðu için doðrudan kendi transform'unu etkiler.
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
