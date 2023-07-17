using System;
using System.Collections.Generic;

public class SceneModel
{
    public void Init()
    {
        // 对场景中动态物体进行空间划分
        // 树Dynamic
        PartFunction(DynamicList);
    
        // 对场景中的静态物体进行空间划分
        // 树Static
        PartFunction(StaticList);
    }

    /// <summary>
    /// 空间划分算法
    /// </summary>
    public void PartFunction(节点)
    {
        // 以x轴为基准，n个元素，从小到大，求前n/2（TopK问题），递归时x轴和y轴交替
        left节点=前n/2;
        right节点=后n/2;

        // 控制在每个叶子节点上的gameObject数量为100，100可根据实际情况去调整
        if n / 2 <= 100
        {
            结束；return;
        }

        // 递归
        PartFunction(left节点);
        PartFunction(right节点);
    }

    // OnCameraMove与OnCameraMoveEnd方法可根据需求进行二选一
    /// 接收相机移动事件
    /// 相机在移动时实时调用，或者每移动xx像素时调用
    public void OnCameraMove()
    {
        相交List = 树Dynamic与相机相交的部份
        foreach (var 子SceneBlock in 相交List)
        {
            foreach (var itemModel in SceneBlock.GetSceneItemList)
            {
                if (itemModel.IsInCamera())
                {
                    obj = ObjectPoolManager.Get(itemModel);
                    obj与itemModel关联
                }
            }
        }
        
        相交ListStatic = 树Static与相机相交部份
        同上
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
        从下至上，递归itemModel与其父节点，重新划分，直到移动过的itemModel可以正确划分
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
        a = 物体包围盒
        b = 相机视角包围盒
        return a和b相交
        
        如包围盒判断的性能不佳，则考虑使用点与相机位置来判断，在进屏幕之前把对象显示出来
        return false;
    }

    public void Move()
    {
        // 通知SceneModel
    }
}
