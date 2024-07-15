using System;

namespace Assets.Scripts.ServicesScripts
{
    public class Services
    {
        public static Services Container => _container ?? (_container = new Services());    
        private static Services _container;

        public TService Register<TService>(TService service) where TService : IService
        {
            Implementation<TService>.ServiceInstance = service;
            return Implementation<TService>.ServiceInstance;
        }

        public TService Get<TService>() where TService : IService =>
            Implementation<TService>.ServiceInstance;


        private static class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}
