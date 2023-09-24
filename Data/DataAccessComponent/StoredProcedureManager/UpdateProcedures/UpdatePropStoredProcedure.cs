

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdatePropStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Prop' object.
    /// </summary>
    public class UpdatePropStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdatePropStoredProcedure' object.
        /// </summary>
        public UpdatePropStoredProcedure()
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
                this.ProcedureName = "Prop_Update";

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
