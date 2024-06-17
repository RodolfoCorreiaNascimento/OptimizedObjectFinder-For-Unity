using UnityEngine;
using System.Collections.Generic;
using System.Text;

public static class OptimizedObjectFinderExtensions
{
    private static Dictionary<int, List<GameObject>> prefixDictionary = new Dictionary<int, List<GameObject>>();

    public static GameObject FindObjectByPrefix(this GameObject gameObject, int targetPrefix)
    {
        if (!prefixDictionary.ContainsKey(targetPrefix))
        {
            RefreshCache(); // Atualiza o cache se necessário
        }

        if (prefixDictionary.ContainsKey(targetPrefix))
        {
            List<GameObject> objects = prefixDictionary[targetPrefix];

            foreach (GameObject obj in objects)
            {
                if (GetPrefix(obj.name) == targetPrefix)
                {
                    return obj;
                }
            }
        }

        return null;
    }

    public static void RefreshCache()
    {
        prefixDictionary.Clear();

        // Find all GameObjects in the scene
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // Check if object name starts with a numeric character
            if (char.IsDigit(obj.name[0]))
            {
                int prefix = GetPrefix(obj.name);

                if (!prefixDictionary.ContainsKey(prefix))
                {
                    prefixDictionary[prefix] = new List<GameObject>();
                }

                prefixDictionary[prefix].Add(obj);
            }
        }
    }

    public static int GetPrefix(string name)
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
            return -1; // Ou outro valor padrão que indique erro, se necessário
        }
    }

    public static GameObject FindObject(this GameObject gameObject, int targetPrefix)
    {
        if (gameObject != null)
        {
            GameObject foundObject = gameObject.FindObjectByPrefix(targetPrefix);

            if (foundObject != null)
            {
                return foundObject;
            }
        }

        return null;
    }
}
