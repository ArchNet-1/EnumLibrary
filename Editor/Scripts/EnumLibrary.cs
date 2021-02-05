using System;
using System.Collections.Generic;
using UnityEngine;

namespace ArchNet.Library.Enum
{
    /// <summary>
    /// Description : Enum Library ( had a list of image and color model )
    /// </summary>
    [CreateAssetMenu(fileName = "NewEnumLibrary", menuName = "CasualFantasy/EnumLibrary")]
    public class EnumLibrary : ScriptableObject
    {

        #region SerializeField

        // List of Image Model
        [SerializeField] private List<ImageModel> _imageModels = new List<ImageModel>();

        // List of Color Model
        [SerializeField] private List<ColorModel> _colorsModels = new List<ColorModel>();

        #endregion

        #region Public Methods

        /// <summary>
        /// Description : Get type from string
        /// </summary>
        /// <param name="pColorLibrary"></param>
        /// <returns></returns>
        public Type GetEnum(ColorLibrary pColorLibrary)
        {
            if(false == IsExist(pColorLibrary))
            {
                return null;
            }

            ColorModel lColorModel = GetColorModel(pColorLibrary);

            Type lResult = EnumExtension.GetEnumType(lColorModel.GetEnum());

            return lResult;
        }



        /// <summary>
        /// Description : Get type from string
        /// </summary>
        /// <param name="pEnumName"></param>
        /// <returns></returns>
        public Type GetEnum(ImageLibrary pImageLibrary)
        {
            if (false == IsExist(pImageLibrary))
            {
                return null;
            }

            ImageModel lImageModel = GetImageModel(pImageLibrary);

            Type lResult = EnumExtension.GetEnumType(lImageModel.GetEnum());

            return lResult;
        }

        /// <summary>
        /// Description : return enum name
        /// </summary>
        /// <param name="pImageLibrary"></param>
        /// <returns></returns>
        public string GetEnumName(ImageLibrary pImageLibrary)
        {
            if (false == IsExist(pImageLibrary))
            {
                return null;
            }

            ImageModel lImageModel = GetImageModel(pImageLibrary);

            string lResult = lImageModel.GetEnum();

            return lResult;
        }

        /// <summary>
        /// Description : return enum name
        /// </summary>
        /// <param name="pColorLibrary"></param>
        /// <returns></returns>
        public string GetEnumName(ColorLibrary pColorLibrary)
        {
            if (false == IsExist(pColorLibrary))
            {
                return null;
            }

            ColorModel lColorModel = GetColorModel(pColorLibrary);

            string lResult = lColorModel.GetEnum();

            return lResult;
        }

        #endregion

        #region Private Methods

        #region Getter

        /// <summary>
        /// Description : return the color models list
        /// </summary>
        /// <returns></returns>
        private List<ColorModel> GetColorModels()
        {
            return _colorsModels;
        }

        /// <summary>
        /// Description : return the image models list
        /// </summary>
        /// <returns></returns>
        private List<ImageModel> GetImageModels()
        {
            return _imageModels;
        }

        #endregion

        #region Setter

        /// <summary>
        /// Description : set the color models list
        /// </summary>
        /// <returns></returns>
        private void SetColorModels(List<ColorModel> pColorModels)
        {
            _colorsModels = pColorModels;
        }

        /// <summary>
        /// Description : set the image models list
        /// </summary>
        /// <returns></returns>
        private void SetImageModels(List<ImageModel> pImageModels)
        {
            _imageModels = pImageModels;
        }

        #endregion

        #region CRUD

        /// <summary>
        /// Description : Add in Image Model List
        /// </summary>
        /// <param name="pColorModel"></param>
        private void AddInList(ImageModel pImageModel)
        {
            if (false == IsInList(pImageModel))
            {
                GetImageModels().Add(pImageModel);
            }
        }

        /// <summary>
        /// Description : Add in Color Model List
        /// </summary>
        /// <param name="pColorModel"></param>
        private void AddInList(ColorModel pColorModel)
        {
            if (false == IsInList(pColorModel))
            {
                GetColorModels().Add(pColorModel);
            }
        }

        /// <summary>
        /// Description : Remove Image Model List
        /// </summary>
        /// <param name="pColorModel"></param>
        private void RemoveInList(ImageModel pImageModel)
        {
            if (true == IsInList(pImageModel))
            {
                GetImageModels().Remove(pImageModel);
            }
        }

        /// <summary>
        /// Description : Remove Color Model List
        /// </summary>
        /// <param name="pColorModel"></param>
        private void RemoveInList(ColorModel pColorModel)
        {
            if (true == IsInList(pColorModel))
            {
                GetColorModels().Remove(pColorModel);
            }
        }


        #endregion

        /// <summary>
        /// Description : return a image model from a color library
        /// </summary>
        /// <param name="pColorLibrary"></param>
        /// <returns></returns>
        private ColorModel GetColorModel(ColorLibrary pColorLibrary)
        {
            ColorModel lResult = null;

            foreach (ColorModel lColorModel in GetColorModels())
            {
                if (lColorModel.GetColorLibrary() == pColorLibrary)
                {
                    lResult = lColorModel;
                }
            }

            return lResult;
        }


        /// <summary>
        /// Description : return a image model from a image library
        /// </summary>
        /// <param name="pImageLibrary"></param>
        /// <returns></returns>
        private ImageModel GetImageModel(ImageLibrary pImageLibrary)
        {
            ImageModel lResult = null;

            foreach (ImageModel lImageModel in GetImageModels())
            {
                if (lImageModel.GetImageLibrary() == pImageLibrary)
                {
                    lResult = lImageModel;
                }
            }

            return lResult;
        }

        /// <summary>
        /// Description : The library exist in the enum list
        /// </summary>
        /// <param name="pColorLibrary"></param>
        /// <returns></returns>
        private bool IsExist(ColorLibrary pColorLibrary)
        {
            bool lResult = false;

            foreach (ColorModel lColorModel in GetColorModels())
            {
                if (lColorModel.GetColorLibrary() == pColorLibrary)
                {
                    lResult = true;
                }
            }

            return lResult;
        }

        /// <summary>
        /// Description : The library exist in the enum list
        /// </summary>
        /// <param name="pImageLibrary"></param>
        /// <returns></returns>
        private bool IsExist(ImageLibrary pImageLibrary)
        {
            bool lResult = false;

            foreach (ImageModel lImageModel in GetImageModels())
            {
                if (lImageModel.GetImageLibrary() == pImageLibrary)
                {
                    lResult = true;
                }
            }

            return lResult;
        }

        /// <summary>
        /// Description : Check if the image model is in list
        /// </summary>
        /// <param name="pColorModel"></param>
        /// <returns></returns>
        private bool IsInList(ImageModel pImageModel)
        {
            bool lResult = false;

            foreach(ImageModel lImageModel in GetImageModels())
            {
                if(lImageModel == pImageModel)
                {
                    lResult = true;
                }
            }

            return lResult;
        }

        /// <summary>
        /// Description : Check if the color model is in list
        /// </summary>
        /// <param name="pColorModel"></param>
        /// <returns></returns>
        private bool IsInList(ColorModel pColorModel)
        {
            bool lResult = false;

            foreach (ColorModel lColorModel in GetColorModels())
            {
                if (lColorModel == pColorModel)
                {
                    lResult = true;
                }
            }

            return lResult;
        }


        #endregion

        #region Editor Methods

        /// <summary>
        /// Description : Add a Color Model
        /// </summary>
        public void AddColorModel()
        {
           AddInList(new ColorModel("", null));
        }

        /// <summary>
        /// Description : Add a Image Model
        /// </summary>
        public void AddImageModel()
        {
            AddInList(new ImageModel("", null));
        }

        ///// <summary>
        ///// Description : Save Library
        ///// </summary>
        //public void SaveLibrary()
        //{
        //    if (_colorsModels == null || _imageModels == null)
        //    {
        //        return;
        //    }

        //    if (_colorsModels.Count == 0 && _imageModels.Count == 0)
        //    {
        //        Debug.LogWarning("The enum List is empty");
        //    }


        //}

        #endregion
    }
}
