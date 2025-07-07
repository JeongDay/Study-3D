using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiTower : MonoBehaviour
{
    public enum HanoiLevel { LV1 = 3, LV2, LV3 }
    public HanoiLevel hanoiLevel;

    public Transform boardTf;
    public GameObject[] donutPrefabs;

    public BoardBar[] bars;

    public static GameObject selectedDonut;
    public static bool isSelected;
    
    IEnumerator Start()
    {
        for (int i = (int)hanoiLevel - 1; i >= 0; i--)
        {
            var donut = Instantiate(donutPrefabs[i]);
            bars[0].PushDonut(donut);
            yield return new WaitForSeconds(1f);
        }
    }
}