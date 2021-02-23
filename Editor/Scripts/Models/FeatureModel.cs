namespace ArchNet.Library.Enum
{
    /// <summary>
    /// [LIBRARY] - [ARCH NET] - [ENUM]  Base model
    /// author : LOUIS PAKEL
    /// </summary>
    [System.Serializable]
    public class FeatureModel
    {
        #region Fields

        // List of items
        private string _enum = "";

        public int _index = 0;

        #endregion

        #region Getter

        /// <summary>
        /// Description : return the enums's list from the feature
        /// </summary>
        /// <returns></returns>
        public string GetEnum()
        {
            return _enum;
        }

        /// <summary>
        /// Description : return the enum index of the library
        /// </summary>
        /// <returns></returns>
        public int GetIndex()
        {
            return _index;
        }


        #endregion

        #region Setter

        /// <summary>
        /// Description : set the enums's list from the feature
        /// </summary>
        /// <returns></returns>
        public void SetEnum(string pEnum)
        {
            _enum = pEnum;
        }

        /// <summary>
        /// Description : Set the enum index of the library
        /// </summary>
        /// <param name="pMaxValue"></param>
        public void SetIndex(int pIndex)
        {
            _index = pIndex;
        }

        #endregion
    }
}
