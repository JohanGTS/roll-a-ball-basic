using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiarEscena : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Niveles");
    }

    public void Level1()
    {
        SceneManager.LoadSceneAsync("lvl1");
    }

    public void Level2()
    {
        SceneManager.LoadSceneAsync("lvl2");
    }

    public void Level3()
    {
        SceneManager.LoadSceneAsync("lvl3");
    }

    public void Level4()
    {
        SceneManager.LoadSceneAsync("lvl4");
    }public void Level5()
    {
        SceneManager.LoadSceneAsync("lvl5");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
