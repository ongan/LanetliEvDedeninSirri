using UnityEngine;

public class SimpleRotator : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        // Bu script, üzerine eklendiði objeyi her saniye Y ekseni etrafýnda
        // 'rotationSpeed' kadar döndürür.
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Hata ayýklama için konsola da yazdýralým.
        Debug.Log("Rotating cube! Current Y rotation: " + transform.eulerAngles.y);
    }
}
