using Unity.VisualScripting;
using UnityEngine;

public class Example : MonoBehaviour
{
    private OptimizedObjectFinder finder;

    void Start()
    {
        finder = FindObjectOfType<OptimizedObjectFinder>(); // Encontra o OptimizedObjectFinder na cena
        
    }

    void Update()
    {
        // Example:
        GameObject obj = finder.FindObject(IDGameObject.Instance.Ball); 
        transform.position = obj.transform.position;
        if (obj != null)
        {
            Debug.Log($"Object Found: {obj}");
        }
    }
}
