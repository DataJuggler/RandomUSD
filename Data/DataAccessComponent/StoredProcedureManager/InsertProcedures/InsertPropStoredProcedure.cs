

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertPropStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Prop' object.
    /// </summary>
    public class InsertPropStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertPropStoredProcedure' object.
        /// </summary>
        public InsertPropStoredProcedure()
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
                this.ProcedureName = "Prop_Insert";

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
