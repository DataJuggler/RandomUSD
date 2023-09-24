

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllScenesStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Scene' objects.
    /// </summary>
    public class FetchAllScenesStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllScenesStoredProcedure' object.
        /// </summary>
        public FetchAllScenesStoredProcedure()
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
                this.ProcedureName = "Scene_FetchAll";

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
