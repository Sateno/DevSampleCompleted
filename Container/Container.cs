using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private Dictionary<Type, Type> mappings = new Dictionary<Type, Type>();
        public void Bind(Type interfaceType, Type implementationType)
        {
            if(mappings.ContainsKey(interfaceType)) 
            {
                throw new ArgumentException($"A mapping for {interfaceType} already exists");
            } 

            mappings[interfaceType] = implementationType;
        }
        public T Get<T>()
        {
            if(mappings.ContainsKey(typeof(T)))
            {
                return (T)Activator.CreateInstance(mappings[typeof(T)]);
            }
            else
            {
                throw new InvalidOperationException($"No mapping found for {typeof(T)}");
            }
        }
    }
}