

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Material
    [Serializable]
    public partial class Material
    {

        #region Private Variables
        #endregion

        #region Constructor
        public Material()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Material Clone()
            {
                // Create New Object
                Material newMaterial = (Material) this.MemberwiseClone();

                // Return Cloned Object
                return newMaterial;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
