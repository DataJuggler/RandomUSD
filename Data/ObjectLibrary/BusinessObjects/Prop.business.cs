

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Prop
    [Serializable]
    public partial class Prop
    {

        #region Private Variables
        private Material material;
        #endregion

        #region Constructor
        public Prop()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Prop Clone()
            {
                // Create New Object
                Prop newProp = (Prop) this.MemberwiseClone();

                // Return Cloned Object
                return newProp;
            }
            #endregion

        #endregion

        #region Properties

            #region Material
            /// <summary>
            /// This property gets or sets the value for 'Material'.
            /// </summary>
            public Material Material
            {
                get { return material; }
                set { material = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
