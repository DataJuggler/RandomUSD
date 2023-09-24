

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindPropStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Prop' object.
    /// </summary>
    public class FindPropStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindPropStoredProcedure' object.
        /// </summary>
        public FindPropStoredProcedure()
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
                this.ProcedureName = "Prop_Find";

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
