

#region using statements

using ApplicationLogicComponent.DataBridge;
using DataAccessComponent.DataManager;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class MaterialMethods
    /// <summary>
    /// This class contains methods for modifying a 'Material' object.
    /// </summary>
    public class MaterialMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'MaterialMethods' object.
        /// </summary>
        public MaterialMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteMaterial(Material)
            /// <summary>
            /// This method deletes a 'Material' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Material' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteMaterial(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteMaterialStoredProcedure deleteMaterialProc = null;

                    // verify the first parameters is a(n) 'Material'.
                    if (parameters[0].ObjectValue as Material != null)
                    {
                        // Create Material
                        Material material = (Material) parameters[0].ObjectValue;

                        // verify material exists
                        if(material != null)
                        {
                            // Now create deleteMaterialProc from MaterialWriter
                            // The DataWriter converts the 'Material'
                            // to the SqlParameter[] array needed to delete a 'Material'.
                            deleteMaterialProc = MaterialWriter.CreateDeleteMaterialStoredProcedure(material);
                        }
                    }

                    // Verify deleteMaterialProc exists
                    if(deleteMaterialProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.MaterialManager.DeleteMaterial(deleteMaterialProc, dataConnector);

                        // Create returnObject.Boolean
                        returnObject.Boolean = new NullableBoolean();

                        // If delete was successful
                        if(deleted)
                        {
                            // Set returnObject.Boolean.Value to true
                            returnObject.Boolean.Value = NullableBooleanEnum.True;
                        }
                        else
                        {
                            // Set returnObject.Boolean.Value to false
                            returnObject.Boolean.Value = NullableBooleanEnum.False;
                        }
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'Material' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Material' to delete.
            /// <returns>A PolymorphicObject object with all  'Materials' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Material> materialListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllMaterialsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get MaterialParameter
                    // Declare Parameter
                    Material paramMaterial = null;

                    // verify the first parameters is a(n) 'Material'.
                    if (parameters[0].ObjectValue as Material != null)
                    {
                        // Get MaterialParameter
                        paramMaterial = (Material) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllMaterialsProc from MaterialWriter
                    fetchAllProc = MaterialWriter.CreateFetchAllMaterialsStoredProcedure(paramMaterial);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    materialListCollection = this.DataManager.MaterialManager.FetchAllMaterials(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(materialListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = materialListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FindMaterial(Material)
            /// <summary>
            /// This method finds a 'Material' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Material' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindMaterial(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Material material = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindMaterialStoredProcedure findMaterialProc = null;

                    // verify the first parameters is a 'Material'.
                    if (parameters[0].ObjectValue as Material != null)
                    {
                        // Get MaterialParameter
                        Material paramMaterial = (Material) parameters[0].ObjectValue;

                        // verify paramMaterial exists
                        if(paramMaterial != null)
                        {
                            // Now create findMaterialProc from MaterialWriter
                            // The DataWriter converts the 'Material'
                            // to the SqlParameter[] array needed to find a 'Material'.
                            findMaterialProc = MaterialWriter.CreateFindMaterialStoredProcedure(paramMaterial);
                        }

                        // Verify findMaterialProc exists
                        if(findMaterialProc != null)
                        {
                            // Execute Find Stored Procedure
                            material = this.DataManager.MaterialManager.FindMaterial(findMaterialProc, dataConnector);

                            // if dataObject exists
                            if(material != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = material;
                            }
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region InsertMaterial (Material)
            /// <summary>
            /// This method inserts a 'Material' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Material' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertMaterial(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Material material = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertMaterialStoredProcedure insertMaterialProc = null;

                    // verify the first parameters is a(n) 'Material'.
                    if (parameters[0].ObjectValue as Material != null)
                    {
                        // Create Material Parameter
                        material = (Material) parameters[0].ObjectValue;

                        // verify material exists
                        if(material != null)
                        {
                            // Now create insertMaterialProc from MaterialWriter
                            // The DataWriter converts the 'Material'
                            // to the SqlParameter[] array needed to insert a 'Material'.
                            insertMaterialProc = MaterialWriter.CreateInsertMaterialStoredProcedure(material);
                        }

                        // Verify insertMaterialProc exists
                        if(insertMaterialProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.MaterialManager.InsertMaterial(insertMaterialProc, dataConnector);
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region UpdateMaterial (Material)
            /// <summary>
            /// This method updates a 'Material' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Material' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateMaterial(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Material material = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateMaterialStoredProcedure updateMaterialProc = null;

                    // verify the first parameters is a(n) 'Material'.
                    if (parameters[0].ObjectValue as Material != null)
                    {
                        // Create Material Parameter
                        material = (Material) parameters[0].ObjectValue;

                        // verify material exists
                        if(material != null)
                        {
                            // Now create updateMaterialProc from MaterialWriter
                            // The DataWriter converts the 'Material'
                            // to the SqlParameter[] array needed to update a 'Material'.
                            updateMaterialProc = MaterialWriter.CreateUpdateMaterialStoredProcedure(material);
                        }

                        // Verify updateMaterialProc exists
                        if(updateMaterialProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.MaterialManager.UpdateMaterial(updateMaterialProc, dataConnector);

                            // Create returnObject.Boolean
                            returnObject.Boolean = new NullableBoolean();

                            // If save was successful
                            if(saved)
                            {
                                // Set returnObject.Boolean.Value to true
                                returnObject.Boolean.Value = NullableBooleanEnum.True;
                            }
                            else
                            {
                                // Set returnObject.Boolean.Value to false
                                returnObject.Boolean.Value = NullableBooleanEnum.False;
                            }
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

        #region Properties

            #region DataManager 
            public DataManager DataManager 
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
