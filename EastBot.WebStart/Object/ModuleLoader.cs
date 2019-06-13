using EastBot.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Unity;

namespace ConsoleApp3
{
    public class ModuleLoader : IModuleLoader
    {
        public List<IPlugin> LoadedModules { get; private set; }

        private IUnityContainer container;

        public ModuleLoader(IUnityContainer container)
        {
            this.container = container;

            LoadedModules = new List<IPlugin>();
        }

        public void LoadAndRegisterModules()
        {
            var files = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "EastBot.Modules.*.dll");
            foreach (var file in files)
            {
                Type pluginType = typeof(IPlugin);
                Assembly assembly = Assembly.LoadFile(file);
                foreach (var type in assembly.GetTypes())
                {
                    if (pluginType.IsAssignableFrom(type))
                    {
                        IPlugin loadedPlugin = container.Resolve(type) as IPlugin;
                        loadedPlugin.Register(container);
                        LoadedModules.Add(loadedPlugin);
                    }
                }
            }
        }
    }
}
