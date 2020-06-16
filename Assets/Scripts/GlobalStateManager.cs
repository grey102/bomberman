using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStateManager : MonoBehaviour
{
    public GameObject GameOverCanvas;
    public GameObject Bomberman;
    public GameObject YouWinCanvas;
    public GameObject Enemy;

    private void Update()
    {
        if (Bomberman == null)
        {
            GameOverCanvas.SetActive(true);
        }
        else
        {
            GameOverCanvas.SetActive(false);
        }

        if (Enemy == null)
        {
            YouWinCanvas.SetActive(true);
        }
        else
        {
            YouWinCanvas.SetActive(false);
        }
    }

}
