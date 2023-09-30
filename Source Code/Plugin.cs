using BepInEx;
using System;
using UnityEngine;
using Utilla;

namespace Computerbackgrounds
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(info.GUID, info.Name, info.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public GameObject pcmesh;
        public GameObject pcmeshplane;

        void Start()
        {
            /* A lot of Gorilla Tag systems will not be set up when start is called /*
			/* Put code in OnGameInitialized to avoid null references */

            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnEnable()
        {
            /* Set up your mod here */
            /* Code here runs at the start and whenever your mod is enabled*/

            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            /* Undo mod setup here */
            /* This provides support for toggling mods with ComputerInterface, please implement it :) */
            /* Code here runs whenever your mod is disabled (including if it disabled on startup)*/

            HarmonyPatches.RemoveHarmonyPatches();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            Debug.Log("is initialized");
            setup();
        }
        public void setup()
        {
            pcmesh = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/-- PhysicalComputer UI --/monitor/");
            pcmesh.GetComponent<Renderer>().enabled = false;
            pcmeshplane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            pcmeshplane.transform.position = new Vector3(-68.865f, 11.979f, -83.3944f);
            pcmeshplane.transform.rotation = Quaternion.Euler(84.4765f, 67.1952f, -0.0001f);
            pcmeshplane.transform.localScale = new Vector3(0.069f, 0.206f, 0.046f);
            pcmeshplane.AddComponent<background>();
        }
        

   
    }
}
