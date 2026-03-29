using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class WallBreakManager : MonoBehaviour
{
    public int totalWalls = 3;

    private HashSet<GameObject> destroyedWalls = new HashSet<GameObject>();

    public void OnWallDestroyed(GameObject wallObject)
    {
        if (destroyedWalls.Contains(wallObject)) return;

        destroyedWalls.Add(wallObject);
        Debug.Log($"Wall ถูกทำลาย: {wallObject.name} | รวม: {destroyedWalls.Count}/{totalWalls}");

        if (destroyedWalls.Count >= totalWalls)
        {
            Debug.Log("ครบแล้ว — กำลังโหลด Credit");


            if (Application.CanStreamedLevelBeLoaded("Credit"))
            {
                SceneManager.LoadScene("Credit");
            }
            else
            {
                Debug.LogError("Scene 'Credit' ไม่อยู่ใน Build Settings!");
            }
        }
    }
}