// Bu bir sýnýf (class) deðil, bir sözleþmedir.
// Bu yüzden ": MonoBehaviour" kýsmýný siliyoruz.
public interface IInteractable
{
    // Bu sözleþmeyi imzalayan her sýnýf, bu iki metoda sahip olmak ZORUNDADIR.

    /// <summary>
    /// Oyuncu etkileþime girdiðinde çalýþacak olan ana metot.
    /// </summary>
    void Interact();

    /// <summary>
    /// Oyuncu nesneye baktýðýnda görünecek olan ipucu metnini döndürür.
    /// </summary>
    /// <returns>Örn: "Kapýyý Aç", "Notu Oku"</returns>
    string GetInteractText();
}
