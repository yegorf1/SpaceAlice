using System;
using System.Collections.Generic;
using System.Linq;
using SpaceAlice.Core.Exceptions;

namespace SpaceAlice.Core.States {
    public class StateMachine {
        private readonly Dictionary<string, IState> _states;
        
        public StateMachine() {
            _states = new Dictionary<string, IState>();
            
            LookForStates();
        }

        private void LookForStates() {
            AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(IState).IsAssignableFrom(type))
                .ToList()
                .ForEach(RegisterStateType);
        }

        public void RegisterStateType(Type type) {
            var instance = (IState) Activator.CreateInstance(type);
            RegisterStateInstance(instance);
        }

        public void RegisterStateInstance(IState instance) {
            if (ContainsState(instance.Name)) {
                throw new StateMachineException($"State with name '{instance.Name}' already exists.");
            }

            _states.Add(instance.Name, instance);
        }

        private bool ContainsState(string instanceName) => _states.ContainsKey(instanceName);
    }
}