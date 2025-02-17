using System;
using System.Collections.Generic;
using GenericModConfigMenu.ModOption;
using StardewModdingAPI;

namespace GenericModConfigMenu.Framework
{
    internal class ModConfig
    {
        public class ModPage
        {
            public string Name { get; }
            public string DisplayName { get; set; }
            public List<Action<string, object>> ChangeHandler { get; } = new();
            public List<BaseModOption> Options { get; set; } = new();

            public ModPage(string name)
            {
                this.Name = name;
                this.DisplayName = this.Name;
            }
        }

        /// <summary>The name of the mod which registered the mod configuration.</summary>
        public string ModName => this.ModManifest.Name;

        /// <summary>The manifest for the mod which registered the mod configuration.</summary>
        public IManifest ModManifest { get; }
        public Action RevertToDefault { get; }
        public Action SaveToFile { get; }
        public Dictionary<string, ModPage> Options { get; } = new();

        public bool DefaultOptedIngame { get; set; } = false;

        public ModPage ActiveRegisteringPage;

        public ModPage ActiveDisplayPage = null;

        public bool HasAnyInGame = false;

        public ModConfig(IManifest manifest, Action revertToDefault, Action saveToFile)
        {
            this.ModManifest = manifest;
            this.RevertToDefault = revertToDefault;
            this.SaveToFile = saveToFile;
            this.Options.Add("", this.ActiveRegisteringPage = new ModPage(""));
        }
    }
}
