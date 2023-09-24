

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindSceneStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Scene' object.
    /// </summary>
    public class FindSceneStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindSceneStoredProcedure' object.
        /// </summary>
        public FindSceneStoredProcedure()
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
                this.ProcedureName = "Scene_Find";

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
