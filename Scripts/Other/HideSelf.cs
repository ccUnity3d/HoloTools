using UnityEngine;

namespace HoloTools.Unity.Other
{
    /// <summary>
    /// HideSelf - give object ability to hide self
    /// </summary>
    public class HideSelf : MonoBehaviour
    {
        #region Public Fields
        
        public bool active = true;

        #endregion

        #region Public Properties

        public bool Active
        {
            get
            {
                active = gameObject.activeSelf;

                return active;
            }
            set
            {
                active = value;

                gameObject.SetActive(active);
            }
        }

        #endregion

        #region Main Methods

        private void Awake()
        {
            Active = active;
        }

        #endregion
    }
}
