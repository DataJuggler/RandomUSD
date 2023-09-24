

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteMaterialStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Material' object.
    /// </summary>
    public class DeleteMaterialStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteMaterialStoredProcedure' object.
        /// </summary>
        public DeleteMaterialStoredProcedure()
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
                this.ProcedureName = "Material_Delete";

                // Set tableName
                this.TableName = "Material";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
