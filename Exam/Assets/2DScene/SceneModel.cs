using System;
using System.Collections.Generic;

public class SceneModel
{
    // 对场景中动态物体进行空间划分
    // 树Dynamic
    // PartSceneDynamic();
    
    // 对场景中的静态物体进行空间划分
    // 树Static
    // PartSceneStatic();

    /// <summary>
    /// 接收相机移动事件
    /// 相机在移动时实时调用，或者每移动xx像素时调用
    /// </summary>
    public void OnCameraMove()
    {
        // 遍历树Dynamic，找出与相机相交的 相交List
        // foreach (var 子SceneBlock in 相交List)
        // {
        //     foreach (var itemModel in SceneBlock.GetSceneItemList)
        //     {
        //         if (itemModel.IsInCamera())
        //         {
        //             obj = ObjectPoolManager.Get(itemModel);
        //             obj与itemModel关联
        //         }
        //     }
        // }
        
        // 相机与树Static相交的叶子节点
        // 同上
    }

    /// <summary>
    /// 相机移动结束
    /// </summary>
    public void OnCameraMoveEnd()
    {
        OnCameraMove();
    }

    public void OnSceneItemMove(SceneItemModel itemModel)
    {
        // 递归itemModel与其父节点，重新划分，直到移动过的itemModel可以正确划分
    }
}

public class SceneBlock
{
    public SceneBlock left;
    public SceneBlock right;
    public WeakReference parent;

    private List<SceneItemModel> _list;
}

public class SceneItemModel
{
    public bool IsInCamera()
    {
        // a = 物体包围盒
        // b = 相机视角包围盒
        // return a和b相交)
        
        // 如包围盒判断的性能不佳，则考虑使用点与相机位置来判断，在进屏幕之前把对象显示出来
        return false;
    }

    public void Move()
    {
        // 通知SceneModel
    }
}
