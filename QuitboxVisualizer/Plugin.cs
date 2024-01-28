using BepInEx;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace QuitboxVisualizer
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        void Start()
        {
            HarmonyPatches.ApplyHarmonyPatches();
        }
    }
}
