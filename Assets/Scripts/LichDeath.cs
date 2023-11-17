using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class LichDeath : MonoBehaviour
{
    public GameObject chest;
    private EnemyController enemyController;

    private void Start()
    {
        enemyController= GetComponent<EnemyController>();
    }


    private void OnDestroy()
    {
        chest.SetActive(true);
    }




}
