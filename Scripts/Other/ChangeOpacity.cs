// Copyright (c) HoloGroup (http://holo.group). All rights reserved.

using UnityEngine;
using HoloTools.Unity.Menu;
using System.Collections.Generic;
using HoloTools.Unity.Utils;

namespace HoloTools.Unity.Other
{
    public class ChangeOpacity : MonoBehaviour
    {
        #region Public Fields

        public bool IsEnable = true;

        public float Opacity = 0;

        [Tooltip("NumInput required.")]
        public NumInput NumInput;

        #endregion

        #region Private Fields

        private List<MeshRenderer> renderersList = new List<MeshRenderer>();
        private List<Material> materialsCopy = new List<Material>();

        #endregion

        #region Inner Classes

        public static class Shaders
        {
            public static Shader standardShader = Shader.Find("Standard");

            public static Shader unlitColor = Shader.Find("Unlit/Color");
            public static Shader unlitTexture = Shader.Find("Unlit/Texture");
            public static Shader unlitTransparent = Shader.Find("Meta/Tools/Unlit/Transparent");

            public static Shader vertexLit = Shader.Find("Legacy Shaders/VertexLit");
            public static Shader vertexLitTransparent = Shader.Find("Legacy Shaders/Transparent/VertexLit");

            public static Shader diffuse = Shader.Find("Legacy Shaders/Diffuse");
            public static Shader diffuseTransparent = Shader.Find("Legacy Shaders/Transparent/Diffuse");

            public static Shader bumpedDiffuse = Shader.Find("Legacy Shaders/Bumped Diffuse");
            public static Shader bumpedDiffuseTransparent = Shader.Find("Legacy Shaders/Transparent/Bumped Diffuse");

            public static Shader bumpedSpecular = Shader.Find("Legacy Shaders/Bumped Specular");
            public static Shader bumpedSpecularTransparent = Shader.Find("Legacy Shaders/Transparent/Bumped Specular");
        }

        #endregion

        #region Main Methods

        private void Awake()
        {
            var arr = GetComponentsInChildren<MeshRenderer>();
            renderersList.AddRange(arr);

            for (int i = 0; i < renderersList.Count; i++)
            {
                var renderer = renderersList[i];

                if (renderer != null)
                {
                    materialsCopy.Clear();

                    // Loop across all renderer materials
                    for (int j = 0; j < renderer.sharedMaterials.Length; j++)
                    {
                        var mat = renderer.sharedMaterials[j];

                        if (mat != null)
                        {
                            if (Opacity == 1)
                            {
                                Opacity = mat.color.a; // Set opacity
                            }

                            materialsCopy.Add(new Material(mat)); // Create a temporary copy of material
                        }
                    }

                    renderer.sharedMaterials = materialsCopy.ToArray();
                }
            }

            if (NumInput)
            {
                NumInput.OnValueChanged += OnValueChanged;
            }
        }

        private void OnValueChanged()
        {
            if (NumInput && NumInput.Value > 0)
            {
                Opacity = NumInput.Value;

                for (int i = 0; i < renderersList.Count; i++)
                {
                    var renderer = renderersList[i];

                    if (renderer != null)
                    {
                        for (int j = 0; j < renderer.sharedMaterials.Length; j++)
                        {
                            var newMat = renderer.sharedMaterials[j];

                            if (newMat != null)
                            {
                                renderer.sharedMaterials[j] = SupportShaderOpacity(newMat); // return material with opacity
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Utility Methods

        public Material SupportShaderOpacity(Material targetMaterial)
        {
            /*
            Supported shaders:
             - Standart (specular setup),
             - Unlit,
             - Vertext Lit,
             - Bumped Diffuse,
             - Bumped Specular,
             - Diffuse
            */
            string shaderName = targetMaterial.shader.name;

            if (Opacity >= 0 && Opacity <= 1f)
            {
                if (shaderName.Contains("Standard"))
                {
                    StandardShaderUtils.ChangeRenderMode(targetMaterial, StandardShaderUtils.BlendMode.Fade);
                }
                else if (shaderName.Contains("Unlit") && !shaderName.Contains("Transparent"))
                {
                    targetMaterial.shader = Shaders.unlitTransparent;
                }
                else if (shaderName.Contains("VertexLit") && !shaderName.Contains("Transparent"))
                {
                    targetMaterial.shader = Shaders.vertexLitTransparent;
                }
                else if (shaderName.Contains("Bumped Diffuse") && !shaderName.Contains("Transparent"))
                {
                    targetMaterial.shader = Shaders.bumpedDiffuseTransparent;
                }
                else if (shaderName.Contains("Bumped Specular") && !shaderName.Contains("Transparent"))
                {
                    targetMaterial.shader = Shaders.bumpedSpecularTransparent;
                }
                else if (shaderName.Contains("Diffuse") && !shaderName.Contains("Transparent"))
                {
                    targetMaterial.shader = Shaders.diffuseTransparent;
                }
            }
            else if (Opacity == 1f)
            {
                if (shaderName.Contains("Standard"))
                {
                    StandardShaderUtils.ChangeRenderMode(targetMaterial, StandardShaderUtils.BlendMode.Opaque);
                }
                else if (shaderName.Contains("Unlit") && shaderName.Contains("Transparent"))
                {
                    if (targetMaterial.mainTexture != null)
                    {
                        targetMaterial.shader = Shaders.unlitTexture;
                    }
                    else
                    {
                        targetMaterial.shader = Shaders.unlitColor;
                    }
                }
                else if (shaderName.Contains("VertexLit") && shaderName.Contains("Transparent"))
                {
                    targetMaterial.shader = Shaders.vertexLit;
                }
                else if (shaderName.Contains("Bumped Diffuse") && shaderName.Contains("Transparent"))
                {
                    targetMaterial.shader = Shaders.bumpedDiffuse;
                }
                else if (shaderName.Contains("Bumped Specular") && shaderName.Contains("Transparent"))
                {
                    targetMaterial.shader = Shaders.bumpedSpecular;
                }
                else if (shaderName.Contains("Diffuse") && shaderName.Contains("Transparent"))
                {
                    targetMaterial.shader = Shaders.diffuse;
                }
            }

            if (IsEnable)
            {
                Color newColor = targetMaterial.color;
                newColor.a = Opacity;
                targetMaterial.color = newColor;
            }

            return targetMaterial;
        }

        #endregion
    }
}