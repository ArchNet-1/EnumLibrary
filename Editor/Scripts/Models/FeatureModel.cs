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
        private string _enum;

        private int _maxValue;

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
        /// Description : return the max value of the library
        /// </summary>
        /// <returns></returns>
        public int GetMaxValue()
        {
            return _maxValue;
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
        /// Description : Set the max value of the library
        /// </summary>
        /// <param name="pMaxValue"></param>
        public void SetMaxValue(int pMaxValue)
        {
            _maxValue = pMaxValue;
        }

        #endregion
    }
}
