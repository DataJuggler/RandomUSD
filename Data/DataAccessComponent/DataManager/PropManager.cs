

#region using statements

using DataAccessComponent.DataManager.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager
{

    #region class PropManager
    /// <summary>
    /// This class is used to manage a 'Prop' object.
    /// </summary>
    public class PropManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'PropManager' object.
        /// </summary>
        public PropManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteProp()
            /// <summary>
            /// This method deletes a 'Prop' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteProp(DeletePropStoredProcedure deletePropProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deletePropProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllProps()
            /// <summary>
            /// This method fetches a  'List<Prop>' object.
            /// This method uses the 'Props_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Prop>'</returns>
            /// </summary>
            public List<Prop> FetchAllProps(FetchAllPropsStoredProcedure fetchAllPropsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Prop> propCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allPropsDataSet = this.DataHelper.LoadDataSet(fetchAllPropsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allPropsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allPropsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            propCollection = PropReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return propCollection;
            }
            #endregion

            #region FindProp()
            /// <summary>
            /// This method finds a  'Prop' object.
            /// This method uses the 'Prop_Find' procedure.
            /// </summary>
            /// <returns>A 'Prop' object.</returns>
            /// </summary>
            public Prop FindProp(FindPropStoredProcedure findPropProc, DataConnector databaseConnector)
            {
                // Initial Value
                Prop prop = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet propDataSet = this.DataHelper.LoadDataSet(findPropProc, databaseConnector);

                    // Verify DataSet Exists
                    if(propDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(propDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Prop
                            prop = PropReader.Load(row);
                        }
                    }
                }

                // return value
                return prop;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perorm Initialization For This Object
            /// </summary>
            private void Init()
            {
                // Create DataHelper object
                this.DataHelper = new DataHelper();
            }
            #endregion

            #region InsertProp()
            /// <summary>
            /// This method inserts a 'Prop' object.
            /// This method uses the 'Prop_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertProp(InsertPropStoredProcedure insertPropProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertPropProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateProp()
            /// <summary>
            /// This method updates a 'Prop'.
            /// This method uses the 'Prop_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateProp(UpdatePropStoredProcedure updatePropProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updatePropProc, databaseConnector);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region DataHelper
            /// <summary>
            /// This object uses the Microsoft Data
            /// Application Block to execute stored
            /// procedures.
            /// </summary>
            internal DataHelper DataHelper
            {
                get { return dataHelper; }
                set { dataHelper = value; }
            }
            #endregion

            #region DataManager
            /// <summary>
            /// A reference to this objects parent.
            /// </summary>
            internal DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
