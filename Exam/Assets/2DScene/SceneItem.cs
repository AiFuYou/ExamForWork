using UnityEngine;

public class SceneItem : MonoBehaviour
{
    /// <summary>
    /// 在相机中由可见状态切换为不可见状态时调用
    /// </summary>
    private void OnBecameInvisible()
    {
        // 设置对象状态
        // 对象回收到对象池
        // 取消与SceneItemModel的关联
    }
}
