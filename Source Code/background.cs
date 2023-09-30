using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Computerbackgrounds
{
    
    public class background : MonoBehaviour
    {
        public Material placeholder;
        public GameObject gorilla;
        public void Start()
        {
           placeholder = new Material(Shader.Find("GorillaTag/UberShader"));
            placeholder.shaderKeywords = new string[]
            {
                "_USE_TEXTURE",
            };

            string AppPath = Application.dataPath;
            AppPath = AppPath.Replace("/Gorilla Tag_Data", "");
            string path = AppPath + @"/BepInEx/plugins/ComputerBackground/";

            Byte[] bytes = File.ReadAllBytes(Directory.GetFiles(path, "*.png")[0]);


            Debug.Log(Directory.GetFiles(path, "*.png")[0]);
            Texture2D loadTexture = new Texture2D(1, 1);
            ImageConversion.LoadImage(loadTexture, bytes);
            loadTexture.Apply();
            byte[] debugImage = loadTexture.EncodeToPNG();
            File.WriteAllBytes(path + "/../Img1.png", debugImage);
            ;
            placeholder.mainTexture = loadTexture;
        }
        public void Update()
        {

            this.gameObject.GetComponent<MeshRenderer>().material = placeholder;
        }
    }
    

    
}
