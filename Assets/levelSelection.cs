using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSelection : MonoBehaviour
{
    public List<GameObject> firstMenu;
    public List<GameObject> levels;

    public void levelSelect()
    {
        foreach (var g in firstMenu)
        {
            g.SetActive(false);
        }

        foreach (var h in levels)
        {
            h.SetActive(true);
        }
    }

    public void mainMenu()
    {
        foreach (var g in firstMenu)
        {
            g.SetActive(true);
        }

        foreach (var h in levels)
        {
            h.SetActive(false);
        }
    }
}
