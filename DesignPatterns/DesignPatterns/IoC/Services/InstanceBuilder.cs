using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DesignPatterns.IoC.Services
{
   public  class InstanceBuilder
    {
        static InstanceBuilder builder = null;
        static InstanceBuilder()
        {
            builder = new InstanceBuilder();
        }
        private InstanceBuilder()
        {
        }
        public static InstanceBuilder GetInstance() => builder;

        public object GetNewObject(Type type)
        {
            object result = null;
            try
            {
                result = Activator.CreateInstance(type);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Cannot create instance of this type\n{ex.Message}");
                return result;
            }
        }
        
    }
}
