using ArchNet.Library.Image;

namespace ArchNet.Library.Enum
{
    /// <summary>
    /// [LIBRARY] - [ARCH NET] - [ENUM] ImageLibrary model
    /// author : LOUIS PAKEL
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
