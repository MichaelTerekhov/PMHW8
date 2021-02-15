using DesignPatterns.IoC.Models;
using System;
using System.Collections.Generic;

namespace DesignPatterns.IoC.Services
{
    public class ServiceCollection : IServiceCollection
    {
        Dictionary<Type, ServiceRegistrationModel> _registeredServices = new Dictionary<Type, ServiceRegistrationModel>();
        public IServiceCollection AddTransient<T>()
        {
            RegisterInContainer<T>(Lifetime.Transient);
            return this;
        }
        
        public IServiceCollection AddTransient<T>(Func<T> factory)
        {
            if (factory == null)
                throw new ArgumentNullException("You cannot add this to the service");
            RegisterInContainer<T>(factory.Invoke(), Lifetime.Transient);
            return this;
        }

        public IServiceCollection AddTransient<T>(Func<IServiceProvider, T> factory)
        {
            if (factory == null)
                throw new ArgumentNullException("You cannot add this to the service");
            if (_registeredServices.ContainsKey(typeof(T)))
                _registeredServices.Remove(typeof(T));
            _registeredServices.Add(typeof(T), new ServiceRegistrationModel(Lifetime.Transient) { ObjectType = typeof(T), Impl = factory as Func<IServiceProvider, object> });
            return this;
        }

        public IServiceCollection AddSingleton<T>() 
        {
            RegisterInContainer<T>(Lifetime.Singleton);
            return this;
        }
        

        public IServiceCollection AddSingleton<T>(T service)
        {
            RegisterInContainer<T>(service,Lifetime.Singleton);
            return this;
        }

        public IServiceCollection AddSingleton<T>(Func<T> factory)
        {
            if (factory == null) 
                throw new ArgumentNullException("You cannot add this to the service");
            RegisterInContainer<T>(factory.Invoke(), Lifetime.Singleton);
            return this;
        }

        public IServiceCollection AddSingleton<T>(Func<IServiceProvider, T> factory)
        {
            if (factory == null)
                throw new ArgumentNullException("You cannot add this to the service");
            if (_registeredServices.ContainsKey(typeof(T)))
                _registeredServices.Remove(typeof(T));
            _registeredServices.Add(typeof(T), new ServiceRegistrationModel(Lifetime.Singleton) { ObjectType = typeof(T),Impl = factory as Func<IServiceProvider, object> });
            return this;
        }

        public IServiceProvider BuildServiceProvider() => new ServiceProvider(_registeredServices);
      
        private void RegisterInContainer<T>(Lifetime lifetime)
        {
            if (_registeredServices.ContainsKey(typeof(T)))
                _registeredServices.Remove(typeof(T));
            _registeredServices.Add(typeof(T), new ServiceRegistrationModel(lifetime) {ObjectType=typeof(T)});
        }
        private void RegisterInContainer<T>(object instance,Lifetime lifetime)
        {
            if (_registeredServices.ContainsKey(typeof(T)))
                _registeredServices.Remove(typeof(T));
            _registeredServices.Add(typeof(T), new ServiceRegistrationModel(lifetime) { ObjectType = typeof(T), Instance = instance });
        }
    }
}