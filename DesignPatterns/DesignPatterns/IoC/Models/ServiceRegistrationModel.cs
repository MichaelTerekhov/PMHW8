using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.IoC.Models
{ 
    public class ServiceRegistrationModel
    {
        private ServiceRegistrationModel()
        { 
        }
        public ServiceRegistrationModel(Lifetime lifetime)
        {
            LifeTime = lifetime;
        }
        public ServiceRegistrationModel(Lifetime lifetime , Type service)
        {
            LifeTime = lifetime;
            ObjectType = service;   
        }
        public ServiceRegistrationModel(Lifetime lifetime, Type service, object instance)
        {
            LifeTime = lifetime;
            ObjectType = service;
            Instance = instance;
        }
        public ServiceRegistrationModel(Lifetime lifetime, Type service, Func<IServiceProvider,object> impl)
        {
            LifeTime = lifetime;
            ObjectType = service;
            Impl = impl;
        }
        public Func<IServiceProvider, object> Impl { get; set; }
        public Type ObjectType { get; set; }
        public Lifetime LifeTime { get; set; }
        public object Instance { get; set; }


    }
}
