using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScene : MonoBehaviour
{
    [SerializeField]
    private string firstSceneName;

    // Start is called before the first frame update
    public void Start()
    {
        gameObject.GetComponent<ScenesManager>().PlayScene(firstSceneName);
    }

}
