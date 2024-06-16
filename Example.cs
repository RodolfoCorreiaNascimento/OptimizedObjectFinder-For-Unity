using UnityEngine;

public class Example : MonoBehaviour
{
    private OptimizedObjectFinder finder;
    private int targetPrefix = 121; // Define o prefixo numérico desejado

    void Start()
    {
        finder = FindObjectOfType<OptimizedObjectFinder>(); // Encontra o OptimizedObjectFinder na cena

        if (finder != null)
        {
            GameObject foundObject = finder.FindObjectByPrefix(targetPrefix); // Chama o método para encontrar o objeto com o prefixo especificado

            if (foundObject != null)
            {
                Debug.Log("Objeto encontrado: " + foundObject.name);
                // Aqui você pode realizar outras operações com o objeto encontrado, se necessário
            }
            else
            {
                Debug.Log("Objeto com prefixo " + targetPrefix + " não encontrado.");
            }
        }
        else
        {
            Debug.LogError("OptimizedObjectFinder não encontrado na cena.");
        }
    }
}
