

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

    #region class MaterialManager
    /// <summary>
    /// This class is used to manage a 'Material' object.
    /// </summary>
    public class MaterialManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MaterialManager' object.
        /// </summary>
        public MaterialManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteMaterial()
            /// <summary>
            /// This method deletes a 'Material' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteMaterial(DeleteMaterialStoredProcedure deleteMaterialProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteMaterialProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllMaterials()
            /// <summary>
            /// This method fetches a  'List<Material>' object.
            /// This method uses the 'Materials_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Material>'</returns>
            /// </summary>
            public List<Material> FetchAllMaterials(FetchAllMaterialsStoredProcedure fetchAllMaterialsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Material> materialCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allMaterialsDataSet = this.DataHelper.LoadDataSet(fetchAllMaterialsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allMaterialsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allMaterialsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            materialCollection = MaterialReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return materialCollection;
            }
            #endregion

            #region FindMaterial()
            /// <summary>
            /// This method finds a  'Material' object.
            /// This method uses the 'Material_Find' procedure.
            /// </summary>
            /// <returns>A 'Material' object.</returns>
            /// </summary>
            public Material FindMaterial(FindMaterialStoredProcedure findMaterialProc, DataConnector databaseConnector)
            {
                // Initial Value
                Material material = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet materialDataSet = this.DataHelper.LoadDataSet(findMaterialProc, databaseConnector);

                    // Verify DataSet Exists
                    if(materialDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(materialDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Material
                            material = MaterialReader.Load(row);
                        }
                    }
                }

                // return value
                return material;
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

            #region InsertMaterial()
            /// <summary>
            /// This method inserts a 'Material' object.
            /// This method uses the 'Material_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertMaterial(InsertMaterialStoredProcedure insertMaterialProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertMaterialProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateMaterial()
            /// <summary>
            /// This method updates a 'Material'.
            /// This method uses the 'Material_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateMaterial(UpdateMaterialStoredProcedure updateMaterialProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateMaterialProc, databaseConnector);
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
