using UnityEngine;
using ArchNet.Library.Color;


namespace ArchNet.Library.Enum
{
    /// <summary>
    /// Description : FeatureModel link to ColorLibrary
    /// @Author : Louis PAKEL
    /// </summary>
    [System.Serializable]
    public class ColorModel : FeatureModel
    {
        #region Fields

        public ColorLibrary _colorLibrary;

        #endregion
        public ColorModel(string pEnum, ColorLibrary pColorLibrary)
        {
            SetEnum(pEnum);
            SetColorLibrary(pColorLibrary);
        }

        #region Getter

        /// <summary>
        /// Description : return the color library of the model
        /// </summary>
        /// <returns></returns>
        public ColorLibrary GetColorLibrary()
        {
            return _colorLibrary;
        }


        #endregion

        #region Setter

        /// <summary>
        /// Description : set the color library of the model
        /// </summary>
        /// <returns></returns>
        public void SetColorLibrary(ColorLibrary pColoribrary)
        {
            _colorLibrary = pColoribrary;
        }


        #endregion
    }
}
