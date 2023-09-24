

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertMaterialStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Material' object.
    /// </summary>
    public class InsertMaterialStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertMaterialStoredProcedure' object.
        /// </summary>
        public InsertMaterialStoredProcedure()
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
                this.ProcedureName = "Material_Insert";

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
