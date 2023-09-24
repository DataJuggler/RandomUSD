

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class MaterialController
    /// <summary>
    /// This class controls a(n) 'Material' object.
    /// </summary>
    public class MaterialController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'MaterialController' object.
        /// </summary>
        public MaterialController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateMaterialParameter
            /// <summary>
            /// This method creates the parameter for a 'Material' data operation.
            /// </summary>
            /// <param name='material'>The 'Material' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateMaterialParameter(Material material)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = material;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Material tempMaterial)
            /// <summary>
            /// Deletes a 'Material' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Material_Delete'.
            /// </summary>
            /// <param name='material'>The 'Material' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Material tempMaterial)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteMaterial";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempmaterial exists before attemptintg to delete
                    if(tempMaterial != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteMaterialMethod = this.AppController.DataBridge.DataOperations.MaterialMethods.DeleteMaterial;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateMaterialParameter(tempMaterial);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteMaterialMethod, parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Test For True
                            if (returnObject.Boolean.Value == NullableBooleanEnum.True)
                            {
                                // Set Deleted To True
                                deleted = true;
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(Material tempMaterial)
            /// <summary>
            /// This method fetches a collection of 'Material' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Material_FetchAll'.</summary>
            /// <param name='tempMaterial'>A temporary Material for passing values.</param>
            /// <returns>A collection of 'Material' objects.</returns>
            public List<Material> FetchAll(Material tempMaterial)
            {
                // Initial value
                List<Material> materialList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.MaterialMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateMaterialParameter(tempMaterial);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Material> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        materialList = (List<Material>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return materialList;
            }
            #endregion

            #region Find(Material tempMaterial)
            /// <summary>
            /// Finds a 'Material' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Material_Find'</param>
            /// </summary>
            /// <param name='tempMaterial'>A temporary Material for passing values.</param>
            /// <returns>A 'Material' object if found else a null 'Material'.</returns>
            public Material Find(Material tempMaterial)
            {
                // Initial values
                Material material = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempMaterial != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.MaterialMethods.FindMaterial;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateMaterialParameter(tempMaterial);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Material != null))
                        {
                            // Get ReturnObject
                            material = (Material) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return material;
            }
            #endregion

            #region Insert(Material material)
            /// <summary>
            /// Insert a 'Material' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Material_Insert'.</param>
            /// </summary>
            /// <param name='material'>The 'Material' object to insert.</param>
            /// <returns>The id (int) of the new  'Material' object that was inserted.</returns>
            public int Insert(Material material)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Materialexists
                    if(material != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.MaterialMethods.InsertMaterial;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateMaterialParameter(material);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, insertMethod , parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Set return value
                            newIdentity = returnObject.IntegerValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref Material material)
            /// <summary>
            /// Saves a 'Material' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='material'>The 'Material' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Material material)
            {
                // Initial value
                bool saved = false;

                // If the material exists.
                if(material != null)
                {
                    // Is this a new Material
                    if(material.IsNew)
                    {
                        // Insert new Material
                        int newIdentity = this.Insert(material);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            material.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Material
                        saved = this.Update(material);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Material material)
            /// <summary>
            /// This method Updates a 'Material' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Material_Update'.</param>
            /// </summary>
            /// <param name='material'>The 'Material' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Material material)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(material != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.MaterialMethods.UpdateMaterial;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateMaterialParameter(material);
                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, updateMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.Boolean != null) && (returnObject.Boolean.Value == NullableBooleanEnum.True))
                        {
                            // Set saved to true
                            saved = true;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
