

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllPropsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Prop' objects.
    /// </summary>
    public class FetchAllPropsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllPropsStoredProcedure' object.
        /// </summary>
        public FetchAllPropsStoredProcedure()
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
                this.ProcedureName = "Prop_FetchAll";

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
