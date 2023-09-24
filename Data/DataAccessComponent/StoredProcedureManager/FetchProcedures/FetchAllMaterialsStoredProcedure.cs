

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllMaterialsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Material' objects.
    /// </summary>
    public class FetchAllMaterialsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllMaterialsStoredProcedure' object.
        /// </summary>
        public FetchAllMaterialsStoredProcedure()
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
                this.ProcedureName = "Material_FetchAll";

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
