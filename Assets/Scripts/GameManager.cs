using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //There is only one GameManager instance
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject("GameManager");
                    instance = singleton.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    //References accessible by all
    public GameObject alice;
    public Shrinker shrinker;
    public Inventory_Object_Trigger object_trigger;
    public Canvas maincanvas;
    public Camera MainCamera;
    public Camera finalCamera;


    public void restart()
    {
        string currentscenename = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentscenename);
    }

    public void endGame()
    {
        MainCamera.gameObject.SetActive(false);
        alice.gameObject.SetActive(false);
        finalCamera.gameObject.SetActive(true);
        maincanvas.worldCamera = finalCamera;
        maincanvas.transform.GetChild(4).gameObject.SetActive(true);
        maincanvas.transform.GetChild(3).gameObject.SetActive(false);
        maincanvas.transform.GetChild(2).gameObject.SetActive(false);
        maincanvas.transform.GetChild(0).gameObject.SetActive(false);
        maincanvas.transform.GetChild(5).gameObject.SetActive(false);
        maincanvas.transform.GetChild(6).gameObject.SetActive(false);
    }
}
