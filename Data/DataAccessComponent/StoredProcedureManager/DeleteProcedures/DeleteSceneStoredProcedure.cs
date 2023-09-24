

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteSceneStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Scene' object.
    /// </summary>
    public class DeleteSceneStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteSceneStoredProcedure' object.
        /// </summary>
        public DeleteSceneStoredProcedure()
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
                this.ProcedureName = "Scene_Delete";

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
