using ArchNet.Library.Color;
using ArchNet.Library.Image;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ArchNet.Library.Enum
{
    /// <summary>
    /// [LIBRARY] - [ARCH NET] - [ENUM] Library Enum ScriptableObject
    /// author : LOUIS PAKEL
    /// </summary>
    [CreateAssetMenu(fileName = "NewEnumLibrary", menuName = "ArchNet/EnumLibrary")]
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
        /// Description : Get Enums values from enum 
        /// </summary>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public List<string> GetEnumKeys(string pEnum)
        {
            List<string> lResult = new List<string>();

            Type type = GetEnumType(pEnum);
            if (type != null)
            {
                lResult.AddRange(System.Enum.GetNames(type));
            }

            return lResult;
        }


        /// <summary>
        /// Description : Get Enum type
        /// </summary>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public Type GetEnumType(string pEnumName)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var type = assembly.GetType(pEnumName);
                if (type == null)
                    continue;
                if (type.IsEnum)
                    return type;
            }

            return null;
        }

        /// <summary>
        /// Description : Get Index value from enum 
        /// </summary>
        /// <param name="pEnumType"></param>
        /// <returns></returns>
        public int GetEnumValue(Type pEnumType, string pKey)
        {
            int lResult = 0;

            int[] lValues = (int[])System.Enum.GetValues(pEnumType);
            string[] lKeys = System.Enum.GetNames(pEnumType);

            for (int i = 0; i < lKeys.Length; i++)
            {
                if (lKeys[i] == pKey)
                {
                    lResult = lValues[i];
                }
            }

            return lResult;
        }

        /// <summary>
        /// Description : Get type from string
        /// </summary>
        /// <param name="pColorLibrary"></param>
        /// <returns></returns>
        public Type GetEnum(ColorModel pColorModel)
        {
            Type lResult = GetEnumType(pColorModel.GetEnum());

            return lResult;
        }


        /// <summary>
        /// Description : Get type from string
        /// </summary>
        /// <param name="pEnumName"></param>
        /// <returns></returns>
        public Type GetEnum(ImageModel pImageModel)
        {
            Type lResult = GetEnumType(pImageModel.GetEnum());

            return lResult;
        }


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

            Type lResult = GetEnumType(lColorModel.GetEnum());

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

            Type lResult = GetEnumType(lImageModel.GetEnum());

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
           AddInList(new ColorModel("", null, 0));
        }

        /// <summary>
        /// Description : Add a Image Model
        /// </summary>
        public void AddImageModel()
        {
            AddInList(new ImageModel("", null, 0));
        }

        #endregion
    }
}
