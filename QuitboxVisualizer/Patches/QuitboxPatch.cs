using HarmonyLib;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace QuitboxVisualizer.Patches
{
    [HarmonyPatch(typeof(GorillaQuitBox))]
    [HarmonyPatch("Start", MethodType.Normal)]
    internal class QuitboxPatch
    {
        private static Shader warningShader;
        private static AssetBundle bundle;
        
        public static AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }

        private static void Postfix(GorillaQuitBox __instance)
        {
            var go = __instance.gameObject;
            if (go.TryGetComponent<MeshRenderer>(out var renderer))
            {
                if (bundle == null)
                {
                    bundle = LoadAssetBundle("QuitboxVisualizer.Resources.shader");
                    warningShader = bundle.LoadAsset<Shader>("OmegaDangerShader");
                }
                renderer.material = new Material(warningShader);
                renderer.enabled = true;
            }
        }
    }
}
