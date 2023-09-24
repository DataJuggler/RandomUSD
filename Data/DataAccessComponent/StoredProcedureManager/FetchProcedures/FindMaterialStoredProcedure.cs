

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindMaterialStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Material' object.
    /// </summary>
    public class FindMaterialStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindMaterialStoredProcedure' object.
        /// </summary>
        public FindMaterialStoredProcedure()
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
                this.ProcedureName = "Material_Find";

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
