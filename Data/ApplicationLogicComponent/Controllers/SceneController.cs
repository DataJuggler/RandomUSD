

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

    #region class SceneController
    /// <summary>
    /// This class controls a(n) 'Scene' object.
    /// </summary>
    public class SceneController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'SceneController' object.
        /// </summary>
        public SceneController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateSceneParameter
            /// <summary>
            /// This method creates the parameter for a 'Scene' data operation.
            /// </summary>
            /// <param name='scene'>The 'Scene' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateSceneParameter(Scene scene)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = scene;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Scene tempScene)
            /// <summary>
            /// Deletes a 'Scene' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Scene_Delete'.
            /// </summary>
            /// <param name='scene'>The 'Scene' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Scene tempScene)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteScene";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempscene exists before attemptintg to delete
                    if(tempScene != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteSceneMethod = this.AppController.DataBridge.DataOperations.SceneMethods.DeleteScene;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSceneParameter(tempScene);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteSceneMethod, parameters);

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

            #region FetchAll(Scene tempScene)
            /// <summary>
            /// This method fetches a collection of 'Scene' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Scene_FetchAll'.</summary>
            /// <param name='tempScene'>A temporary Scene for passing values.</param>
            /// <returns>A collection of 'Scene' objects.</returns>
            public List<Scene> FetchAll(Scene tempScene)
            {
                // Initial value
                List<Scene> sceneList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.SceneMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateSceneParameter(tempScene);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Scene> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        sceneList = (List<Scene>) returnObject.ObjectValue;
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
                return sceneList;
            }
            #endregion

            #region Find(Scene tempScene)
            /// <summary>
            /// Finds a 'Scene' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Scene_Find'</param>
            /// </summary>
            /// <param name='tempScene'>A temporary Scene for passing values.</param>
            /// <returns>A 'Scene' object if found else a null 'Scene'.</returns>
            public Scene Find(Scene tempScene)
            {
                // Initial values
                Scene scene = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempScene != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.SceneMethods.FindScene;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSceneParameter(tempScene);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Scene != null))
                        {
                            // Get ReturnObject
                            scene = (Scene) returnObject.ObjectValue;
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
                return scene;
            }
            #endregion

            #region Insert(Scene scene)
            /// <summary>
            /// Insert a 'Scene' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Scene_Insert'.</param>
            /// </summary>
            /// <param name='scene'>The 'Scene' object to insert.</param>
            /// <returns>The id (int) of the new  'Scene' object that was inserted.</returns>
            public int Insert(Scene scene)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Sceneexists
                    if(scene != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.SceneMethods.InsertScene;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSceneParameter(scene);

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

            #region Save(ref Scene scene)
            /// <summary>
            /// Saves a 'Scene' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='scene'>The 'Scene' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Scene scene)
            {
                // Initial value
                bool saved = false;

                // If the scene exists.
                if(scene != null)
                {
                    // Is this a new Scene
                    if(scene.IsNew)
                    {
                        // Insert new Scene
                        int newIdentity = this.Insert(scene);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            scene.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Scene
                        saved = this.Update(scene);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Scene scene)
            /// <summary>
            /// This method Updates a 'Scene' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Scene_Update'.</param>
            /// </summary>
            /// <param name='scene'>The 'Scene' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Scene scene)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(scene != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.SceneMethods.UpdateScene;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateSceneParameter(scene);
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
