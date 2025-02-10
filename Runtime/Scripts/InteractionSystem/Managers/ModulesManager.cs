using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ModulesManager : MonoBehaviour
{
    private ITimer timer;
    private List<IModule> modules = new List<IModule>();

    void Start()
    {
        // Trouver le timer dans les enfants
        timer = GetComponentInChildren<ITimer>();
        if (timer == null)
        {
            Debug.LogError("Aucun composant impl�mentant ITimer trouv� parmi les enfants !");
        }

        // Trouver tous les modules dans les enfants
        modules = GetComponentsInChildren<IModule>().ToList();
        if (modules.Count == 0)
        {
            Debug.LogError("Aucun module trouv� parmi les enfants !");
        }
    }

    // Version debug
    void Update()
    {
        if (timer != null && timer.GetRemainingTime() > 0)
        {
            // Compter le nombre de modules termin�s
            int completedModules = modules.Count(m => m.IsFinished());
            int totalModules = modules.Count;

            Debug.Log($"Modules r�solus : {completedModules}/{totalModules}");

            // V�rifier si tous les modules sont termin�s
            if (completedModules == totalModules)
            {
                Debug.Log("Tous les modules sont termin�s ! Bravo !");
            }
            else
            {
                Debug.Log("Il reste encore des modules � r�soudre.");
            }
        }
        else
        {
            Debug.Log("Temps �coul� !");
        }
    }


    /*void Update()
    {
        if (timer != null && timer.GetRemainingTime() > 0)
        {
            // V�rifier si tous les modules sont termin�s
            bool allModulesFinished = modules.All(m => m.IsFinished());

            if (allModulesFinished)
            {
                Debug.Log("Tous les modules sont termin�s ! Bravo !");
            }
            else
            {
                Debug.Log("Il reste encore des modules � r�soudre.");
            }
        }
        else
        {
            Debug.Log("Temps �coul� !");
        }
    }*/

}

