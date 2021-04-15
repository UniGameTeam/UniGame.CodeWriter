using System;
using UniModules.UniCore.Runtime.ReflectionUtils;
using UnityEngine;

namespace RemoteData.Runtime.Attributes
{
    [AttributeUsage(AttributeTargets.Class,Inherited = true)]
    public class InterfaceApiAttribute : Attribute
    {
        public readonly Type[] interfaces;

        public InterfaceApiAttribute(params Type[] interfaces)
        {
            interfaces = interfaces;
            
            foreach (var type in interfaces)
            {
                if (type.IsInterface == false)
                {
                    Debug.LogError($"{nameof(InterfaceApiAttribute)} TYPE {type.GetFormattedName()} not Interface");
                }
            }
        }
    }
}
