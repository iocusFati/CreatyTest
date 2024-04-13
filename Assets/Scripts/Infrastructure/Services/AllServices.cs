using System;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class AllServices
    {
        private static AllServices _instance;
        public static AllServices Container => _instance ??= new AllServices();

        public TService RegisterService<TService>(TService implementation) where TService : IService =>
            Implementation<TService>.ServiceInstance = implementation;
        
        public TService Single<TService>() where TService : IService =>
            Implementation<TService>.ServiceInstance;

        private class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}