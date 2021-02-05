using UnityEngine;
using ArchNet.Library.ImageLibrary;

namespace ArchNet.Library.EnumLibrary
{
    /// <summary>
    /// Description : FeatureModel link to ImageLibrary
    /// @Author : Louis PAKEL
    /// </summary>
    [System.Serializable]
    public class ImageModel : FeatureModel
    {
        #region Fields

        public ImageLibrary _imageLibrary;

        #endregion

        public ImageModel(string pEnum, ImageLibrary pImageLibrary)
        {
            SetEnum(pEnum);
            SetImageLibrary(pImageLibrary);
        }

        #region Getter

        /// <summary>
        /// Description : return the image library of the model
        /// </summary>
        /// <returns></returns>
        public ImageLibrary GetImageLibrary()
        {
            return _imageLibrary;
        }

        #endregion

        #region Setter

        /// <summary>
        /// Description : set the image library of the model
        /// </summary>
        /// <returns></returns>
        public void SetImageLibrary(ImageLibrary pImageLibrary)
        {
            _imageLibrary = pImageLibrary;
        }


        #endregion
    }
}
