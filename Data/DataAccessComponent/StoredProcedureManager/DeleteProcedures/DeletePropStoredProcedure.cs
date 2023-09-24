

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeletePropStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Prop' object.
    /// </summary>
    public class DeletePropStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeletePropStoredProcedure' object.
        /// </summary>
        public DeletePropStoredProcedure()
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
                this.ProcedureName = "Prop_Delete";

                // Set tableName
                this.TableName = "Prop";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
