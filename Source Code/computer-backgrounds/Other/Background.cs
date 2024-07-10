using System;
using System.IO;
using UnityEngine;

namespace Computerbackgrounds.Other
{
    public class Background : MonoBehaviour
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
            string path = AppPath + @"/BepInEx/plugins/computer-backgrounds/";

            string[] imageFiles = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);
            string imagePath = null;

            foreach (string file in imageFiles)
            {
                if (file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                {
                    imagePath = file;
                    break;
                }
            }

            if (imagePath == null)
            {
                Debug.LogError("No PNG or JPG files found in the directory.");
                return;
            }

            Byte[] bytes = File.ReadAllBytes(imagePath);

            Debug.Log(imagePath);
            Texture2D loadTexture = new Texture2D(1, 1);
            ImageConversion.LoadImage(loadTexture, bytes);
            loadTexture.Apply();

            byte[] debugImage = loadTexture.EncodeToPNG();
            File.WriteAllBytes(path + "/../Img1.png", debugImage);

            placeholder.mainTexture = loadTexture;
        }

        public void Update()
        {
            this.gameObject.GetComponent<MeshRenderer>().material = placeholder;
        }
    }
}
