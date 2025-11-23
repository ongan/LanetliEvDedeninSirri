using UnityEngine;
using TMPro; // TextMeshPro'yu kullanabilmek için bu satýrý eklemeliyiz.

public class UIManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject interactionPromptObject; // Metnin kendisini deðil, parent objesini kontrol edeceðiz.
    [SerializeField] private TextMeshProUGUI interactionPromptText;

    // Bu metot, oyuncu etkileþimli bir nesneye baktýðýnda çaðrýlacak.
    public void ShowInteractionPrompt(string text)
    {
        interactionPromptObject.SetActive(true); // Metin objesini görünür yap.
        interactionPromptText.text = text;       // Metnin içeriðini güncelle.
    }

    // Bu metot, oyuncu etkileþimli bir nesneye bakmadýðýnda çaðrýlacak.
    public void HideInteractionPrompt()
    {
        interactionPromptObject.SetActive(false); // Metin objesini gizle.
    }
}
