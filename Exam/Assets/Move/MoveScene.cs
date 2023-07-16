using UnityEngine;
using UnityEngine.UI;

public class MoveScene : MonoBehaviour
{
    public Button btn;
    public GameObject template;
    private GameObject _moveOnceGoParent;


    private void Awake()
    {
        _moveOnceGoParent = new GameObject("MoveOnce");
        btn.onClick.AddListener(AddMoveOnce);
    }

    void Start()
    {
        //只移动一次
        AddMoveOnce();

        //PingPong移动
        AddCube("MovePingPong", new Vector3(1, 5, 0), new Vector3(8, 5, 0), 1, true);
        AddCube("EaseInPingPong", new Vector3(1, 2, 0), new Vector3(8, 2, 0), 1, true, Ease.In);
        AddCube("EaseOutPingPong", new Vector3(1, -1, 0), new Vector3(8, -1, 0), 1, true, Ease.Out);
        AddCube("EaseInOutPingPong", new Vector3(1, -4, 0), new Vector3(8, -4, 0), 1, true, Ease.InOut);
        
        template.SetActive(false);
    }

    private void AddMoveOnce()
    {
        for (int i = 0; i < _moveOnceGoParent.transform.childCount; i++)
        {
            Destroy(_moveOnceGoParent.transform.GetChild(i).gameObject);
        }
        
        AddCube("Move", new Vector3(-8, 5, 0), new Vector3(-1, 5, 0), 1, false, Ease.Linear, true);
        AddCube("EaseIn", new Vector3(-8, 2, 0), new Vector3(-1, 2, 0), 1, false, Ease.In, true);
        AddCube("EaseOut", new Vector3(-8, -1, 0), new Vector3(-1, -1, 0), 1, false, Ease.Out, true);
        AddCube("EaseInOut", new Vector3(-8, -4, 0), new Vector3(-1, -4, 0), 1, false, Ease.InOut, true);
    }

    private void AddCube(string nameStr, Vector3 begin, Vector3 end, float time, bool pingPong = false, Ease ease = Ease.Linear, bool isOnce = false)
    {
        var cube = Instantiate(template);
        cube.name = nameStr;
        if (isOnce)
        {
            cube.transform.SetParent(_moveOnceGoParent.transform);
        }
        cube.SetActive(true);
        MoveManager.Move(cube, begin, end, time, pingPong, ease);
    }
}
