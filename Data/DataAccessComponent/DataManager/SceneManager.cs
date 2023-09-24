

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

    #region class SceneManager
    /// <summary>
    /// This class is used to manage a 'Scene' object.
    /// </summary>
    public class SceneManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'SceneManager' object.
        /// </summary>
        public SceneManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteScene()
            /// <summary>
            /// This method deletes a 'Scene' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteScene(DeleteSceneStoredProcedure deleteSceneProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteSceneProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllScenes()
            /// <summary>
            /// This method fetches a  'List<Scene>' object.
            /// This method uses the 'Scenes_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Scene>'</returns>
            /// </summary>
            public List<Scene> FetchAllScenes(FetchAllScenesStoredProcedure fetchAllScenesProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Scene> sceneCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allScenesDataSet = this.DataHelper.LoadDataSet(fetchAllScenesProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allScenesDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allScenesDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            sceneCollection = SceneReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return sceneCollection;
            }
            #endregion

            #region FindScene()
            /// <summary>
            /// This method finds a  'Scene' object.
            /// This method uses the 'Scene_Find' procedure.
            /// </summary>
            /// <returns>A 'Scene' object.</returns>
            /// </summary>
            public Scene FindScene(FindSceneStoredProcedure findSceneProc, DataConnector databaseConnector)
            {
                // Initial Value
                Scene scene = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet sceneDataSet = this.DataHelper.LoadDataSet(findSceneProc, databaseConnector);

                    // Verify DataSet Exists
                    if(sceneDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(sceneDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Scene
                            scene = SceneReader.Load(row);
                        }
                    }
                }

                // return value
                return scene;
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

            #region InsertScene()
            /// <summary>
            /// This method inserts a 'Scene' object.
            /// This method uses the 'Scene_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertScene(InsertSceneStoredProcedure insertSceneProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertSceneProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateScene()
            /// <summary>
            /// This method updates a 'Scene'.
            /// This method uses the 'Scene_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateScene(UpdateSceneStoredProcedure updateSceneProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateSceneProc, databaseConnector);
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
