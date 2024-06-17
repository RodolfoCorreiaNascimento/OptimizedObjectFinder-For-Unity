using UnityEngine;
using System.Collections.Generic;
using System.Text;

public static class OptimizedObjectFinderExtensions
{
    private static Dictionary<int, GameObject> prefixDictionary = new Dictionary<int, GameObject>();
    private static bool isCacheValid = false;

    public static GameObject FindObjectByPrefix(this GameObject gameObject, int targetPrefix)
    {
        if (!isCacheValid)
        {
            RefreshCache(); // Atualiza o cache se necessário
        }

        GameObject foundObject;
        if (prefixDictionary.TryGetValue(targetPrefix, out foundObject))
        {
            return foundObject;
        }

        return null;
    }

    public static void RefreshCache()
    {
        prefixDictionary.Clear();

        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (char.IsDigit(obj.name[0]))
            {
                int prefix = GetPrefix(obj.name);
                if (!prefixDictionary.ContainsKey(prefix))
                {
                    prefixDictionary[prefix] = obj;
                }
            }
        }

        isCacheValid = true;
    }

    public static int GetPrefix(string name)
    {
        StringBuilder prefixBuilder = new StringBuilder();

        foreach (char c in name)
        {
            if (char.IsDigit(c))
            {
                prefixBuilder.Append(c);
            }
            else if (prefixBuilder.Length > 0) // Stop at first non-digit after digits are found
            {
                break;
            }
        }

        int result;
        if (int.TryParse(prefixBuilder.ToString(), out result))
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

    public static void InvalidateCache()
    {
        isCacheValid = false;
    }
}
