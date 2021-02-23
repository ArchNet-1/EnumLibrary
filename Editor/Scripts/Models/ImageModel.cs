using ArchNet.Library.Image;

namespace ArchNet.Library.Enum
{
    /// <summary>
    /// ImageLibrary model for enum library
    /// author : LOUIS PAKEL
    /// </summary>
    [System.Serializable]
    public class ImageModel : FeatureModel
    {
        #region Fields

        public ImageLibrary _imageLibrary;

        #endregion

        public ImageModel(string pEnum, ImageLibrary pImageLibrary, int pIndex)
        {
            SetEnum(pEnum);
            SetImageLibrary(pImageLibrary);
            SetIndex(pIndex);
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
