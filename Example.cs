using UnityEngine;
using System.Collections.Generic;

public class Example : MonoBehaviour
{
    void Start()
    {
        OptimizedObjectFinder finder = new OptimizedObjectFinder();
        GameObject foundObject = finder.FindObjectByPrefix(2, 20);

        if (foundObject != null)
        {
            Debug.Log("Objeto encontrado: " + foundObject.name);
        }
        else
        {
            Debug.Log("Objeto não encontrado.");
        }


    }
}
