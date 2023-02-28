using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bạn đã hoàn thành màn chơi");
    }
}
