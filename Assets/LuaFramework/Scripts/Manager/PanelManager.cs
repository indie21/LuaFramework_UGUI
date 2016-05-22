using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using LuaInterface;

namespace LuaFramework {
    public class PanelManager : Manager {
        private Transform parent;
        private PrefebManager prefebMgr;

        void Start()
        {
            this.prefebMgr = AppFacade.Instance.
                GetManager<PrefebManager>(ManagerName.Prefeb);
        }

        Transform Parent {
            get {
                if (parent == null) {
                    GameObject go = GameObject.FindWithTag("GuiCamera");
                    if (go != null) parent = go.transform;
                }
                return parent;
            }
        }

        /// <summary>
        /// 创建面板，请求资源管理器
        /// </summary>
        /// <param name="type"></param>
        public void CreatePanel(string name, LuaFunction func = null) {

            string assetName = name + "Panel";
            prefebMgr.CreatePrefeb(name, assetName, Parent, func);

        }
    }
}