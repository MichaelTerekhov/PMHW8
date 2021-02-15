using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.IoC.Services
{
    public  class SingletonBuilder
    {
        static SingletonBuilder builder = null;
        static Dictionary<string, object> _buildedSingletons = new Dictionary<string, object>();
        private SingletonBuilder()
        { 
        }
        static SingletonBuilder()
        {
            builder = new SingletonBuilder();
        }
        public static SingletonBuilder GetSingleton() => builder;
        public object CreateSingleton(Type type)
        {
            object result = null;
            try
            {
                if (_buildedSingletons.ContainsKey(type.Name))
                    result = _buildedSingletons[type.Name];
                else 
                {
                    result = InstanceBuilder.GetInstance().GetNewObject(type);
                    _buildedSingletons.Add(type.Name,result);
                }
            }
            catch (Exception)
            { 
            
            }
            return result;
        }
    }
}
