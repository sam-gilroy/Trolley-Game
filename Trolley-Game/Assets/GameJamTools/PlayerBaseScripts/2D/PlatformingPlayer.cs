using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJamTools
{
    [RequireComponent(typeof(PlatformingController))]
    public abstract class PlatformingPlayer : UPlayer
    {
        protected PlatformingController platformingController;

        /// <summary>
        /// Caching
        /// </summary>
        protected virtual void Awake()
        {
            platformingController = GetComponent<PlatformingController>();
        }

        /// <summary>
        /// Default update -- dont override (or override w/ base call)
        /// </summary>
        private void Update()
        {
            HandleInput();
        }

        /// <summary>
        /// Handles input -- override this for functionality, not update
        /// </summary>
        public abstract void HandleInput();

        /// <summary>
        /// Returns platforming controller
        /// </summary>
        /// <returns></returns>
        public PlatformingController GetPlatformingController()
        {
            return platformingController;
        }
    }
}