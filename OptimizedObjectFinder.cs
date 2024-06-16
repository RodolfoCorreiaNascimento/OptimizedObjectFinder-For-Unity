using UnityEngine;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;

public class OptimizedObjectFinder : MonoBehaviour
{
    #region FindObjByPrefix
    public GameObject FindObjectByPrefix(int targetPrefix)
    {
        List<GameObject> objects = GetAllSceneObjects();

        // Sort the list by prefix extracted from the name
        objects.Sort((obj1, obj2) => GetPrefix(obj1.name).CompareTo(GetPrefix(obj2.name)));

        // Perform optimized binary search using division into 4 parts
        GameObject foundObject = BinarySearchOptimized(objects, targetPrefix);

        // Just for Debug purpose...
        if (foundObject != null)
        {
            //Debug.Log("Objeto encontrado: " + foundObject.name);
        }
        else
        {
            //Debug.Log("Objeto com prefixo " + targetPrefix + " não encontrado.");
        }

        // Loop to print sorted objects
        for (int i = 0; i < objects.Count; i++)
        {
            //Debug.Log("Objeto ordenado [" + i + "]: " + objects[i].name);
        }

        return foundObject;
    }

    #endregion

    #region InsertAllGameObjectsIntoList
    /// <summary>
    /// Get all the GameObjects in the Scene and Add them to a List<GameObject>
    /// </summary>
    private List<GameObject> GetAllSceneObjects()
    {
        List<GameObject> objects = new List<GameObject>();

        // Find all GameObjects in the scene
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (var obj in allObjects)
        {
            // Check if object name starts with a numeric character
            if (char.IsDigit(obj.name[0]))
            {
                objects.Add(obj);
                //Debug.Log("Added object: " + obj.name);
            }
        }

        return objects;
    }

    #endregion

    #region BinarySearchOptimized
    private GameObject BinarySearchOptimized(List<GameObject> objects, int targetPrefix)
    {
        int low = 0;
        int high = objects.Count - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 4;
            int quarterPrefix = GetPrefix(objects[mid].name);

            if (quarterPrefix == targetPrefix)
            {
                // Check the quarter containing the target prefix
                return BinarySearchQuarter(objects, mid, targetPrefix);
            }
            else if (quarterPrefix < targetPrefix)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return null;
    }

    private GameObject BinarySearchQuarter(List<GameObject> objects, int startIndex, int targetPrefix)
    {
        int low = startIndex;
        int high = startIndex + (objects.Count - startIndex - 1) / 4;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            int currentPrefix = GetPrefix(objects[mid].name);

            if (currentPrefix == targetPrefix)
            {
                return objects[mid];
            }
            else if (currentPrefix < targetPrefix)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return null;
    }

    #endregion

    #region GetPrefix

    /// <summary>
    /// Get the first character prefix and convert it to number.
    /// </summary>
    private int GetPrefix(string name)
    {
        // Encontra o primeiro grupo de caracteres numéricos no nome do objeto e converte para int
        StringBuilder prefixBuilder = new StringBuilder();
        bool foundDigit = false;

        foreach (char c in name)
        {
            if (char.IsDigit(c))
            {
                prefixBuilder.Append(c);
                foundDigit = true;
            }
            else if (foundDigit && c == '-')
            {
                break;
            }
            else if (!char.IsDigit(c) && foundDigit)
            {
                // Se encontrou um dígito antes e o próximo caractere não é '-', interrompe
                break;
            }
        }

        int result;
        if (foundDigit && int.TryParse(prefixBuilder.ToString(), out result))
        {
            return result;
        }
        else
        {
            //Debug.LogWarning("Não foi possível converter o prefixo numérico em inteiro: " + prefixBuilder.ToString());
            return -1; // Ou outro valor padrão que indique erro, se necessário
        }
    }

    #endregion

    #region FindObject

    /// <summary>
    /// Insert the ID of the GameObject to return the GameObje itself
    /// Ex: GameObject obj = FindObject(IDGameObject.Instance.Player); then you can use the GameObject
    /// You can test it using Debug.Log($"Object Found: {obj}");
    /// </summary>
    public GameObject FindObject(int targetPrefix)
    {
        if (this.gameObject != null)
        {
            GameObject foundObject = FindObjectByPrefix(targetPrefix); // Chama o método para encontrar o objeto com o prefixo especificado

            if (foundObject != null)
            {
                //Debug.Log("Objeto encontrado: " + foundObject.name);
                // Aqui você pode realizar outras operações com o objeto encontrado, se necessário
                return foundObject;
            }
            else
            {
                return null;
                //Debug.Log("Objeto com prefixo " + targetPrefix + " não encontrado.");
            }
        }
        else
        {
            //Debug.LogError("OptimizedObjectFinder não encontrado na cena.");
        }
        return null;
    }

    #endregion
}
