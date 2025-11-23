using UnityEngine;

// MonoBehaviour'dan sonra bir virgül koyup, imzalayacaðýmýz sözleþmenin adýný yazýyoruz.
public class LightSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] private Light targetLight;
    [SerializeField] private bool isLightOn = true;

    // Unity bu script'i eklediðinde, IInteractable'ý uyguladýðýmýzý görür
    // ve bize kýzar: "Sözleþmedeki metotlarý yazmadýn!". Þimdi onlarý yazalým.

    public void Interact()
    {
        // Durumu tersine çevir
        isLightOn = !isLightOn;
        // Iþýðýn durumunu güncelle
        targetLight.enabled = isLightOn;
    }

    public string GetInteractText()
    {
        // Duruma göre farklý metinler döndür
        if (isLightOn)
        {
            return "Iþýðý Kapat";
        }
        else
        {
            return "Iþýðý Aç";
        }
    }
}
