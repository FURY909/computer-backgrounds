using BepInEx;
using Computerbackgrounds;
using System;
using UnityEngine;
using Utilla;

namespace Computerbackgrounds
{
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(info.GUID, info.Name, info.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public GameObject pcmesh;
        public GameObject pcmeshplane;

        void Start() => Utilla.Events.GameInitialized += OnGameInitialized;

        void OnEnable() => Enabled(true);

        void OnDisable() => Enabled(false);

        void OnGameInitialized(object sender, EventArgs e)
        {
            Debug.Log("Loaded Computer-Backgrounds");
            pcmesh = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/monitor/monitorScreen/");
            pcmesh.GetComponent<Renderer>().enabled = false;
            pcmeshplane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            pcmeshplane.transform.position = new Vector3(-65.4649f, 12f, -80.0021f);
            pcmeshplane.transform.rotation = Quaternion.Euler(84.5283f, 200.3744f, 0.0002f);
            pcmeshplane.transform.localScale = new Vector3(0.069f, 0.106f, 0.046f);
            pcmeshplane.AddComponent<Other.Background>();
        }

        void Enabled(bool enabled = true)
        {
            if(enabled)
            {
                pcmesh = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/monitor/monitorScreen/");
                pcmesh.GetComponent<Renderer>().enabled = false;
                pcmeshplane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                pcmeshplane.transform.position = new Vector3(-65.4649f, 12f, -80.0021f);
                pcmeshplane.transform.rotation = Quaternion.Euler(84.5283f, 200.3744f, 0.0002f);
                pcmeshplane.transform.localScale = new Vector3(0.069f, 0.106f, 0.046f);
                pcmeshplane.AddComponent<Other.Background>();
            }
            else
            {
                pcmesh = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/GorillaComputerObject/ComputerUI/monitor/monitorScreen/");
                pcmesh.GetComponent<Renderer>().enabled = true;
                GameObject.Destroy(pcmeshplane);
            }
        }
    }
}
