namespace ArchNet.Library.Enum
{ 
    [System.Serializable]
    public class FeatureModel
    {
        #region Fields

        // List of items
        public string _enum;

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

        #endregion
    }
}
