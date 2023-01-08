using Features.Common.Worlds;
using Features.Player.Factory;
using Features.Player.Input;
using Features.Player.Movement;
using Morpeh;
using UnityEngine;

namespace Features.Bootstrap
{
    [DisallowMultipleComponent]
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private MovementSystem _movementSystem;
        [SerializeField] private PlayerFactory _playerFactory;

        [SerializeField] private WorldHandler _worldHandler;
        
        private void Start()
        {
            Bootstrap();
        }

        private void Bootstrap()
        {
            var world = World.Create();
            var worldView = new WorldView(world);
            
            var systemsGroup = world.CreateSystemsGroup();
            
            systemsGroup.AddSystem(_inputSystem);
            systemsGroup.AddSystem(_movementSystem);
            
            world.AddSystemsGroup(0, systemsGroup);
            
            _worldHandler.Construct(world);
            _playerFactory.Spawn(worldView);
        }
    }
}