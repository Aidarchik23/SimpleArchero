using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

namespace PlayerCharacter
{
    public class PlayerAttack : MonoBehaviour
    {
        /// <summary>
        /// The weapon that the player will use
        /// </summary>
        [SerializeField]
        [Tooltip("The weapon that the player will use")]
        private BaseWeapon _weapon;

        private void Update()
        {
            if (_weapon.IsAttacking) return;

            _weapon.Attack();
        }
    }
}