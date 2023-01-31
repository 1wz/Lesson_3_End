using System;
using UnityEngine;
using JetBrains.Annotations;
using Object = UnityEngine.Object;

namespace Features.AbilitySystem.Abilities
{
    internal class JumpAbility : IAbility
    {
        private readonly AbilityItemConfig _config;
        private bool jumpingNow = false;


        public JumpAbility([NotNull] AbilityItemConfig config) =>
            _config = config ?? throw new ArgumentNullException(nameof(config));


        public void Apply(IAbilityActivator activator)
        {
            if (jumpingNow) return;
            jumpingNow = true;
            var projectile = Object.Instantiate(_config.Projectile).GetComponent<JumpScript>();
            projectile.StartJump(activator.ViewGameObject.transform, () => { jumpingNow = false; });

        }
    }
}
