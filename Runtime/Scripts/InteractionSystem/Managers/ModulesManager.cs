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
            Debug.LogError("Aucun composant implémentant ITimer trouvé parmi les enfants !");
        }

        // Trouver tous les modules dans les enfants
        modules = GetComponentsInChildren<IModule>().ToList();
        if (modules.Count == 0)
        {
            Debug.LogError("Aucun module trouvé parmi les enfants !");
        }
    }

    // Version debug
    void Update()
    {
        if (timer != null && timer.GetRemainingTime() > 0)
        {
            // Compter le nombre de modules terminés
            int completedModules = modules.Count(m => m.IsFinished());
            int totalModules = modules.Count;

            Debug.Log($"Modules résolus : {completedModules}/{totalModules}");

            // Vérifier si tous les modules sont terminés
            if (completedModules == totalModules)
            {
                Debug.Log("Tous les modules sont terminés ! Bravo !");
            }
            else
            {
                Debug.Log("Il reste encore des modules à résoudre.");
            }
        }
        else
        {
            Debug.Log("Temps écoulé !");
        }
    }


    /*void Update()
    {
        if (timer != null && timer.GetRemainingTime() > 0)
        {
            // Vérifier si tous les modules sont terminés
            bool allModulesFinished = modules.All(m => m.IsFinished());

            if (allModulesFinished)
            {
                Debug.Log("Tous les modules sont terminés ! Bravo !");
            }
            else
            {
                Debug.Log("Il reste encore des modules à résoudre.");
            }
        }
        else
        {
            Debug.Log("Temps écoulé !");
        }
    }*/

}

