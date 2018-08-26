using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class gundata
{
    public int id;
    public Transform prefab;
}
public class gunc : MonoBehaviour {
    public static gunc instance;
    public Transform guncontainer;
    public gundata[] list;
    private int _curgunid = 0;
    public gundata curgundata;
    public Transform curgun;
    public int Curgunid
    {
        get
        {
            return _curgunid;
        }

        set
        {
            _curgunid = value;
            curgundata = GetGundata(_curgunid);
            foreach (Transform tf in guncontainer.GetComponentInChildren<Transform>())
            {
                Destroy(tf.gameObject);
            }
           // _curgunid = _curgunid + 1;
           curgun = Instantiate(curgundata.prefab);
            curgun.SetParent(guncontainer);
            curgun.localPosition = Vector3.zero;
        }
    }

    public int Curgunid1
    {
        get
        {
            return _curgunid;
        }

        set
        {
            _curgunid = value;
        }
    }

    // Use this for initialization
    void Start () {
        instance = this;
        Curgunid = 0;
    }
    public void changegun()
    {
        Curgunid = Curgunid + 1 > list.Length - 1 ? 0 : Curgunid + 1;
    }
    #region 获取武器数据
    public gundata GetGundata(int gunid)
    {
        foreach (gundata wd in list)
        {
            if (wd.id == gunid)
            {
                return wd;
            }
        }
        return null;
    }
    #endregion
    // Update is called once per frame
    void Update () {
		
	}
}
