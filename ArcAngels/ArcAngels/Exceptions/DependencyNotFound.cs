using ArcAngels.ArcAngels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcAngels.ArcAngels.Exceptions
{
    public class DependencyNotFound : Exception
    {
        public DependencyNotFound(string message) : base(message)
        {

        }

        public DependencyNotFound(AbstractComponent component) : base($"The following dependencies of the {component.Name} component were not found: {ListToString(component.GetDependencies())}")
        {

        }

        private static string ListToString(List<AbstractComponent> dependencies)
        {
            string dependenciesNames = "";
            for (int i  = 0; i < dependencies.Count; i++)
            {
                dependenciesNames += dependencies[i].Name;
                dependenciesNames += i == dependencies.Count - 1 ? "." : ",";
            }

            return dependenciesNames;
        }
    }
}
