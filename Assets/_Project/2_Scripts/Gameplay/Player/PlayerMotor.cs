// PlayerMotor.cs'in içine eklenecek YENÝ kýsýmlar

using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMotor : MonoBehaviour
{
    // ... (Mevcut deðiþkenler ayný kalýyor) ...
    private CharacterController controller;
    private Vector3 playerVelocity;

    [Header("Movement")]
    public float moveSpeed = 5.0f;
    public float gravity = -9.81f;

    [Header("Looking")]
    public float mouseSensitivityX = 100.0f;

    // --- YENÝ DEÐÝÞKENLER ---
    [Header("Interaction")]
    [Tooltip("Oyuncunun ne kadar uzaða kadar etkileþime girebileceði.")]
    public float interactionDistance = 3f;
    [Tooltip("Etkileþimli nesneleri ayýrt etmek için kullanýlacak katman.")]
    public LayerMask interactableLayer;
    [Tooltip("Iþýný göndereceðimiz kamera.")]
    public Transform cameraTransform; // Bu referansý Start'ta otomatik alacaðýz.
    // -------------------------
    [Header("UI")]
    public UIManager uiManager;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Kamera referansýný otomatik olarak bul
        if (cameraTransform == null)
        {
            cameraTransform = GetComponentInChildren<Camera>().transform;
        }

        if (uiManager == null)
        {
            uiManager = FindObjectOfType<UIManager>();
        }
    }

    void Update()
    {
        HandleMovementAndRotation();
        HandleInteraction(); // Yeni metot çaðrýmýz
    }

    void HandleMovementAndRotation()
    {
        // ... (Bu metodun içeriði ayný, deðiþiklik yok) ...
        bool isGrounded = controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0) { playerVelocity.y = -2f; }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }

    // --- YENÝ METOT ---
    void HandleInteraction()
    {
        // Kameranýn tam ortasýndan ileriye doðru görünmez bir ýþýn (Ray) gönder.
        RaycastHit hit; // Iþýn bir þeye çarparsa, bilgileri burada saklanacak.

        // Physics.Raycast, bir ýþýn gönderir ve bir cisme çarpýp çarpmadýðýný (true/false) döndürür.
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, interactionDistance, interactableLayer))
        {
            // Iþýn bir þeye çarptý!
            // Þimdi çarptýðýmýz þeyin "IInteractable" sözleþmesini imzalayýp imzalamadýðýný kontrol edelim.
            if (hit.collider.TryGetComponent(out IInteractable interactableObject))
            {
                // Evet, imzalamýþ! Bu bir kapý, not veya lamba olabilir, umrumuzda deðil.
                // Sadece onun bir Interact() metodu olduðunu biliyoruz.

                // TODO: Ekranda bir UI metni göster. Þimdilik konsola yazalým.
                uiManager.ShowInteractionPrompt(interactableObject.GetInteractText());

                // Oyuncu 'E' tuþuna basarsa...
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // ...nesnenin kendi Interact() metodunu çaðýr.
                    interactableObject.Interact();
                }
                return;
            }
        }
        // Eðer ýþýn hiçbir "IInteractable" nesneye çarpmadýysa, metni gizle.
        uiManager.HideInteractionPrompt();
    }
    // ------------------
}
