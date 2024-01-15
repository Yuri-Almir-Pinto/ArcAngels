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

        public DependencyNotFound(AbstractComponent component) : base($"The following dependencies of the {component.GetType().Name} component were not found: {ListToString(component.Dependencies)}\n\nOwner: {component.Owner}")
        {

        }

        public DependencyNotFound(Type component) : base($"The following component was not found, and it is required: {component.Name}")
        {

        }

        private static string ListToString(Type[] dependencies)
        {
            string dependenciesNames = "";
            for (int i  = 0; i < dependencies.Length; i++)
            {
                dependenciesNames += dependencies[i].Name;
                dependenciesNames += i == dependencies.Length - 1 ? "." : ",";
            }

            return dependenciesNames;
        }
    }
}
