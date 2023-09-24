

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateSceneStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Scene' object.
    /// </summary>
    public class UpdateSceneStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateSceneStoredProcedure' object.
        /// </summary>
        public UpdateSceneStoredProcedure()
        {
            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Set Procedure Properties
            /// </summary>
            private void Init()
            {
                // Set Properties For This Proc

                // Set ProcedureName
                this.ProcedureName = "Scene_Update";

                // Set tableName
                this.TableName = "Scene";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
