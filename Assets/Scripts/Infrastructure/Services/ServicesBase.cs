using System;
using System.Collections.Generic;

namespace Scripts.Infrastructure.Services
{
    public class ServicesBase
    {
        private static ServicesBase _instance;

        public static ServicesBase instance => _instance ?? (_instance = new ServicesBase());

        //сервисы хранятся в списке
        private readonly Dictionary<Type, IService> _servicesMap;

        public ServicesBase() => _servicesMap = new Dictionary<Type, IService>();

        public void CreateService<TService>(TService newService) where TService : IService
        {
            Type type = typeof(TService);
            _servicesMap[type] = newService;
        }

        public TService GetService<TService>() where TService : IService
        {
            Type type = typeof(TService);
            return (TService)this._servicesMap[type];
        }
        
    }

    
}
