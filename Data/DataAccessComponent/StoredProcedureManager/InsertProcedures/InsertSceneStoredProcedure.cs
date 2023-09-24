

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertSceneStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Scene' object.
    /// </summary>
    public class InsertSceneStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertSceneStoredProcedure' object.
        /// </summary>
        public InsertSceneStoredProcedure()
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
                this.ProcedureName = "Scene_Insert";

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
