

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateMaterialStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Material' object.
    /// </summary>
    public class UpdateMaterialStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateMaterialStoredProcedure' object.
        /// </summary>
        public UpdateMaterialStoredProcedure()
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
                this.ProcedureName = "Material_Update";

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
