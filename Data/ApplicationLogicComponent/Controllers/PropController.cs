

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

    #region class PropController
    /// <summary>
    /// This class controls a(n) 'Prop' object.
    /// </summary>
    public class PropController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'PropController' object.
        /// </summary>
        public PropController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreatePropParameter
            /// <summary>
            /// This method creates the parameter for a 'Prop' data operation.
            /// </summary>
            /// <param name='prop'>The 'Prop' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreatePropParameter(Prop prop)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = prop;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Prop tempProp)
            /// <summary>
            /// Deletes a 'Prop' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Prop_Delete'.
            /// </summary>
            /// <param name='prop'>The 'Prop' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Prop tempProp)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteProp";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempprop exists before attemptintg to delete
                    if(tempProp != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deletePropMethod = this.AppController.DataBridge.DataOperations.PropMethods.DeleteProp;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreatePropParameter(tempProp);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deletePropMethod, parameters);

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

            #region FetchAll(Prop tempProp)
            /// <summary>
            /// This method fetches a collection of 'Prop' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Prop_FetchAll'.</summary>
            /// <param name='tempProp'>A temporary Prop for passing values.</param>
            /// <returns>A collection of 'Prop' objects.</returns>
            public List<Prop> FetchAll(Prop tempProp)
            {
                // Initial value
                List<Prop> propList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.PropMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreatePropParameter(tempProp);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Prop> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        propList = (List<Prop>) returnObject.ObjectValue;
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
                return propList;
            }
            #endregion

            #region Find(Prop tempProp)
            /// <summary>
            /// Finds a 'Prop' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Prop_Find'</param>
            /// </summary>
            /// <param name='tempProp'>A temporary Prop for passing values.</param>
            /// <returns>A 'Prop' object if found else a null 'Prop'.</returns>
            public Prop Find(Prop tempProp)
            {
                // Initial values
                Prop prop = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempProp != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.PropMethods.FindProp;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreatePropParameter(tempProp);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Prop != null))
                        {
                            // Get ReturnObject
                            prop = (Prop) returnObject.ObjectValue;
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
                return prop;
            }
            #endregion

            #region Insert(Prop prop)
            /// <summary>
            /// Insert a 'Prop' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Prop_Insert'.</param>
            /// </summary>
            /// <param name='prop'>The 'Prop' object to insert.</param>
            /// <returns>The id (int) of the new  'Prop' object that was inserted.</returns>
            public int Insert(Prop prop)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Propexists
                    if(prop != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.PropMethods.InsertProp;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreatePropParameter(prop);

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

            #region Save(ref Prop prop)
            /// <summary>
            /// Saves a 'Prop' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='prop'>The 'Prop' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Prop prop)
            {
                // Initial value
                bool saved = false;

                // If the prop exists.
                if(prop != null)
                {
                    // Is this a new Prop
                    if(prop.IsNew)
                    {
                        // Insert new Prop
                        int newIdentity = this.Insert(prop);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            prop.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Prop
                        saved = this.Update(prop);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Prop prop)
            /// <summary>
            /// This method Updates a 'Prop' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Prop_Update'.</param>
            /// </summary>
            /// <param name='prop'>The 'Prop' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Prop prop)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(prop != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.PropMethods.UpdateProp;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreatePropParameter(prop);
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
