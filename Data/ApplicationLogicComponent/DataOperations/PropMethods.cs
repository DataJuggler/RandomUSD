

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

    #region class PropMethods
    /// <summary>
    /// This class contains methods for modifying a 'Prop' object.
    /// </summary>
    public class PropMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'PropMethods' object.
        /// </summary>
        public PropMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteProp(Prop)
            /// <summary>
            /// This method deletes a 'Prop' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Prop' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteProp(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeletePropStoredProcedure deletePropProc = null;

                    // verify the first parameters is a(n) 'Prop'.
                    if (parameters[0].ObjectValue as Prop != null)
                    {
                        // Create Prop
                        Prop prop = (Prop) parameters[0].ObjectValue;

                        // verify prop exists
                        if(prop != null)
                        {
                            // Now create deletePropProc from PropWriter
                            // The DataWriter converts the 'Prop'
                            // to the SqlParameter[] array needed to delete a 'Prop'.
                            deletePropProc = PropWriter.CreateDeletePropStoredProcedure(prop);
                        }
                    }

                    // Verify deletePropProc exists
                    if(deletePropProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.PropManager.DeleteProp(deletePropProc, dataConnector);

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
            /// This method fetches all 'Prop' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Prop' to delete.
            /// <returns>A PolymorphicObject object with all  'Props' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Prop> propListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllPropsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get PropParameter
                    // Declare Parameter
                    Prop paramProp = null;

                    // verify the first parameters is a(n) 'Prop'.
                    if (parameters[0].ObjectValue as Prop != null)
                    {
                        // Get PropParameter
                        paramProp = (Prop) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllPropsProc from PropWriter
                    fetchAllProc = PropWriter.CreateFetchAllPropsStoredProcedure(paramProp);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    propListCollection = this.DataManager.PropManager.FetchAllProps(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(propListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = propListCollection;
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

            #region FindProp(Prop)
            /// <summary>
            /// This method finds a 'Prop' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Prop' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindProp(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Prop prop = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindPropStoredProcedure findPropProc = null;

                    // verify the first parameters is a 'Prop'.
                    if (parameters[0].ObjectValue as Prop != null)
                    {
                        // Get PropParameter
                        Prop paramProp = (Prop) parameters[0].ObjectValue;

                        // verify paramProp exists
                        if(paramProp != null)
                        {
                            // Now create findPropProc from PropWriter
                            // The DataWriter converts the 'Prop'
                            // to the SqlParameter[] array needed to find a 'Prop'.
                            findPropProc = PropWriter.CreateFindPropStoredProcedure(paramProp);
                        }

                        // Verify findPropProc exists
                        if(findPropProc != null)
                        {
                            // Execute Find Stored Procedure
                            prop = this.DataManager.PropManager.FindProp(findPropProc, dataConnector);

                            // if dataObject exists
                            if(prop != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = prop;
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

            #region InsertProp (Prop)
            /// <summary>
            /// This method inserts a 'Prop' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Prop' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertProp(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Prop prop = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertPropStoredProcedure insertPropProc = null;

                    // verify the first parameters is a(n) 'Prop'.
                    if (parameters[0].ObjectValue as Prop != null)
                    {
                        // Create Prop Parameter
                        prop = (Prop) parameters[0].ObjectValue;

                        // verify prop exists
                        if(prop != null)
                        {
                            // Now create insertPropProc from PropWriter
                            // The DataWriter converts the 'Prop'
                            // to the SqlParameter[] array needed to insert a 'Prop'.
                            insertPropProc = PropWriter.CreateInsertPropStoredProcedure(prop);
                        }

                        // Verify insertPropProc exists
                        if(insertPropProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.PropManager.InsertProp(insertPropProc, dataConnector);
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

            #region UpdateProp (Prop)
            /// <summary>
            /// This method updates a 'Prop' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Prop' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateProp(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Prop prop = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdatePropStoredProcedure updatePropProc = null;

                    // verify the first parameters is a(n) 'Prop'.
                    if (parameters[0].ObjectValue as Prop != null)
                    {
                        // Create Prop Parameter
                        prop = (Prop) parameters[0].ObjectValue;

                        // verify prop exists
                        if(prop != null)
                        {
                            // Now create updatePropProc from PropWriter
                            // The DataWriter converts the 'Prop'
                            // to the SqlParameter[] array needed to update a 'Prop'.
                            updatePropProc = PropWriter.CreateUpdatePropStoredProcedure(prop);
                        }

                        // Verify updatePropProc exists
                        if(updatePropProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.PropManager.UpdateProp(updatePropProc, dataConnector);

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
