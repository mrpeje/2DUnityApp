using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ActiveMapHandler();
public class MapGroup : MonoBehaviour
{
    public GameObject[] Maps;
    GameObject ActiveMap;
    public event ActiveMapHandler ActiveMapChanged;
    private void Awake()
    {
        ActiveMap = Maps[0];
    }
    public GameObject GetActiveMap()
    {
        return ActiveMap;
    }
    // Simple solution. Mb will make it better
    public void SetActive(int activeMapID)
    {
        for (int i = 0; i < Maps.Length; i++)
        {
            if (i == activeMapID)
            {
                Maps[i].SetActive(true);
                ActiveMap = Maps[i];
            }
            else
                Maps[i].SetActive(false);

        }
        if (ActiveMapChanged != null)
            ActiveMapChanged();
    }
}
