using BepInEx;
using ComputerBackgrounds;
using System;
using UnityEngine;
using UnityEngine.UIElements;
using static Photon.Pun.UtilityScripts.TabViewManager;
using TMPro;

namespace Computerbackgrounds
{
    [BepInPlugin(info.GUID, info.Name, info.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public GameObject pcmesh;
        public GameObject newtab;
        public GameObject pcmeshplane;
        public GameObject tab;
        public Material tabmat;

        void Start()
        {
            GorillaTagger.OnPlayerSpawned(OnGameInitialized);
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

        void OnGameInitialized()
        {
            Debug.Log("is initialized");
            setup();
        }
        public void setup()
        {
            pcmeshplane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            pcmeshplane.transform.position = new Vector3(-65.4623f, 11.999f, -80.0045f);
            pcmeshplane.transform.rotation = Quaternion.Euler(84.7581f, 200.596f, 0.2129f);
            pcmeshplane.transform.localScale = new Vector3(0.069f, 0.206f, 0.046f);
            pcmeshplane.AddComponent<background>();
            var volume = new Material(Shader.Find("GorillaTag/UberShader"));
            var VolUp = GameObject.CreatePrimitive(PrimitiveType.Cube);
            VolUp.transform.position = new Vector3(-65.1123f, 12.169f, - 80.0745f);
            VolUp.transform.rotation = Quaternion.Euler(84.7581f, 200.596f, 0.2129f);
            VolUp.transform.localScale = new Vector3(0.069f, 0.076f, 0.046f);
            VolUp.name = "volup";
            var VolDown = GameObject.CreatePrimitive(PrimitiveType.Cube);
            VolDown.transform.position = new Vector3(-65.1223f, 11.809f, - 80.0945f);
            VolDown.transform.rotation = Quaternion.Euler(84.7581f, 200.596f, 0.2129f);
            VolDown.transform.localScale = new Vector3(0.069f, 0.076f, 0.046f);
            VolDown.name = "voldown";
            VolDown.GetComponent<MeshRenderer>().material = volume;
            VolUp.GetComponent<MeshRenderer>().material = volume;

        }


    }
}