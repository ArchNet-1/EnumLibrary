using System;
using System.Collections.Generic;
using ArchNet.Library.Enum;

namespace ArchNet.Extension.Enum
{
    /// <summary>
    /// [EXTENSION] - [ARCH NET] - [ENUM] Extension Enum
    /// author : LOUIS PAKEL
    /// </summary>
    public static class EnumExtension
    {

        /// <summary>
        /// Description : Get Enums values from enum 
        /// </summary>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public static List<string> GetEnumKeys(string pEnum)
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
        public static Type GetEnumType(string pEnumName)
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
        public static  int GetEnumValue(Type pEnumType, string pKey)
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
        public static Type GetEnum(ColorModel pColorModel)
        {
            Type lResult = GetEnumType(pColorModel.GetEnum());

            return lResult;
        }


        /// <summary>
        /// Description : Get type from string
        /// </summary>
        /// <param name="pEnumName"></param>
        /// <returns></returns>
        public static Type GetEnum(ImageModel pImageModel)
        {
            Type lResult = GetEnumType(pImageModel.GetEnum());

            return lResult;
        }

    }
}
