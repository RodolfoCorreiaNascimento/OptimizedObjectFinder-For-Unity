using UnityEngine;
using System.Collections.Generic;

public class OptimizedObjectFinder : MonoBehaviour
{
    public GameObject FindObjectByPrefix(int targetPrefix, int maxObjects)
    {
        List<GameObject> objects = new List<GameObject>();

        // Coleta todos os objetos na cena
        for (int i = 1; i <= maxObjects; i++)
        {
            GameObject obj = GameObject.Find(i.ToString() + "-");
            if (obj != null)
            {
                objects.Add(obj);
            }
        }

        // Faz uma busca binária nos objetos coletados
        return BinarySearch(objects, targetPrefix);
    }

    private GameObject BinarySearch(List<GameObject> objects, int targetPrefix)
    {
        int left = 0;
        int right = objects.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int currentPrefix = GetPrefix(objects[mid].name);

            if (currentPrefix == targetPrefix)
            {
                return objects[mid];
            }

            if (currentPrefix < targetPrefix)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return null;
    }

    private int GetPrefix(string name)
    {
        string prefix = "";
        foreach (char c in name)
        {
            if (char.IsDigit(c))
            {
                prefix += c;
            }
            else
            {
                break;
            }
        }
        return int.Parse(prefix);
    }
}
