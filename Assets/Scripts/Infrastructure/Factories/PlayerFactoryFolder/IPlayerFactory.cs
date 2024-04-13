using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.States
{
    public interface IPlayerFactory : IService
    {
        void CreatePlayer(Vector3 at);
    }
}