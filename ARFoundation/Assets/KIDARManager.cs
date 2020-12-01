using UnityEngine;
using UnityEngine.XR.ARFoundation;  // 引用 Foundation API
using UnityEngine.XR.ARSubsystems;  // 引用 Subsystems API
using System.Collections.Generic;   // 引用 系統.集合.一般 包含清單 List

/// <summary>
/// 點擊地面生成物件
/// </summary>
// RC 要求元件：在第一次套用腳本時執行
[RequireComponent(typeof(ARRaycastManager))]
public class KIDARManager : MonoBehaviour
{
    [Header("點擊後要生成的物件")]
    public GameObject obj;
    [Header("AR 管理器")]
    public ARRaycastManager arManager;

    // 滑鼠座標
    private Vector2 pointMouse;
    // 碰撞資訊
    private List<ARRaycastHit> hits;

    /// <summary>
    /// 點擊
    /// </summary>
    private void Tap()
    {
        // 判斷玩家是否點擊
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            pointMouse = Input.mousePosition;           // 滑鼠座標 = 玩家的滑鼠座標

            // 判斷射線是否打到物件
            if (arManager.Raycast(pointMouse, hits, TrackableType.PlaneWithinPolygon))
            {
                // 生成物件(物件，座標，角度)
                // hits[0].pose.position 點擊到地面的第一個位置
                // Quaternion.identity 零角度
                Instantiate(obj, hits[0].pose.position, hits[0].pose.rotation);
            }
        }
    }

    private void Update()
    {
        Tap();
    }
}
