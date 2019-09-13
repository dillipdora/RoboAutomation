using RoboInfra;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RoboAutomation.Utilities
{
    public class MEFContainer
    {
        public static CompositionContainer Container { get; set; }

        /// <summary>
        /// Will get all the exports and add them to container based on Catalogs
        /// </summary>
        static MEFContainer()
        {
            // Assembly list needed for imports
            var assemblyList = new List<string>()
            {
                "RobosLibrary.dll",
                "RoboCommon.dll",
            };

            var catalog = new AggregateCatalog();

            foreach (var assemblyName in assemblyList)
            {
                var assemblyPath = Path.Combine(Environment.CurrentDirectory, assemblyName);
                var assembly = Assembly.LoadFile(assemblyPath);
                catalog.Catalogs.Add(new AssemblyCatalog(assembly));
            }

            //load current assembly into container's catalog
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

            //Create the CompositionContainer with the parts in the catalog
            Container = new CompositionContainer(catalog);
        }

        public void SatisfyImports(object val)
        {
            //Fill the imports of object sent via parameter.
            try
            {
                Container.ComposeParts(val);
            }
            catch (SystemException)
            {
                throw;
            }

        }

    }
}
