using DesignPatterns.IoC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.IoC.Services
{
    public class ServiceProvider : IServiceProvider
    {
        Dictionary<Type, ServiceRegistrationModel> _services = new Dictionary<Type, ServiceRegistrationModel>();
        public ServiceProvider(Dictionary<Type, ServiceRegistrationModel> _services)
        {
            this._services = _services;
        }
        public T GetService<T>()
        {
            object buildResult = null;
            if (_services.ContainsKey(typeof(T)))
            {
                Type buildingType = default;
                var serviceToBuild = _services.Where(service => service.Key == typeof(T));
                if (serviceToBuild.Any(x => x.Value.LifeTime == Lifetime.Singleton))
                {

                    foreach (var m in serviceToBuild)
                    {
                        if (m.Value.Impl == null)
                        {
                            buildingType = m.Value.ObjectType;
                            break;
                        }
                        m.Value.Instance = m.Value.Instance ?? m.Value.Impl.Invoke(this);
                        buildingType = m.Value.Instance.GetType();
                        m.Value.Impl = null;
                    }
                    buildResult = SingletonBuilder.GetSingleton().CreateSingleton(buildingType);
                }
                else if (serviceToBuild.Any(x => x.Value.LifeTime == Lifetime.Transient))
                {
                    foreach (var m in serviceToBuild)
                    {
                        buildingType = m.Value.ObjectType;
                        if (m.Value.Impl != null)
                            return (T)m.Value.Impl.Invoke(this);
                    }
                    
                    buildResult = InstanceBuilder.GetInstance().GetNewObject(buildingType);
                }
            }
            else return default(T);
            return (T)buildResult;
        }
    }
}
