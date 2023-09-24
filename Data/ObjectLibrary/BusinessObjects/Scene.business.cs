

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Scene
    [Serializable]
    public partial class Scene
    {

        #region Private Variables
        #endregion

        #region Constructor
        public Scene()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Scene Clone()
            {
                // Create New Object
                Scene newScene = (Scene) this.MemberwiseClone();

                // Return Cloned Object
                return newScene;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
