using ArchNet.Library.Color;

namespace ArchNet.Library.Enum
{
    /// <summary>
    /// [LIBRARY] - [ARCH NET] - [ENUM] ColorLibrary model
    /// author : LOUIS PAKEL
    /// </summary>
    [System.Serializable]
    public class ColorModel : FeatureModel
    {
        #region Fields

        public ColorLibrary _colorLibrary;

        #endregion
        public ColorModel(string pEnum, ColorLibrary pColorLibrary, int pMaxValue)
        {
            SetEnum(pEnum);
            SetColorLibrary(pColorLibrary);
            SetMaxValue(pMaxValue);
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
