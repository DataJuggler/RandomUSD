

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

    #region class SceneMethods
    /// <summary>
    /// This class contains methods for modifying a 'Scene' object.
    /// </summary>
    public class SceneMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'SceneMethods' object.
        /// </summary>
        public SceneMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteScene(Scene)
            /// <summary>
            /// This method deletes a 'Scene' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Scene' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteScene(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteSceneStoredProcedure deleteSceneProc = null;

                    // verify the first parameters is a(n) 'Scene'.
                    if (parameters[0].ObjectValue as Scene != null)
                    {
                        // Create Scene
                        Scene scene = (Scene) parameters[0].ObjectValue;

                        // verify scene exists
                        if(scene != null)
                        {
                            // Now create deleteSceneProc from SceneWriter
                            // The DataWriter converts the 'Scene'
                            // to the SqlParameter[] array needed to delete a 'Scene'.
                            deleteSceneProc = SceneWriter.CreateDeleteSceneStoredProcedure(scene);
                        }
                    }

                    // Verify deleteSceneProc exists
                    if(deleteSceneProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.SceneManager.DeleteScene(deleteSceneProc, dataConnector);

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
            /// This method fetches all 'Scene' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Scene' to delete.
            /// <returns>A PolymorphicObject object with all  'Scenes' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Scene> sceneListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllScenesStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get SceneParameter
                    // Declare Parameter
                    Scene paramScene = null;

                    // verify the first parameters is a(n) 'Scene'.
                    if (parameters[0].ObjectValue as Scene != null)
                    {
                        // Get SceneParameter
                        paramScene = (Scene) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllScenesProc from SceneWriter
                    fetchAllProc = SceneWriter.CreateFetchAllScenesStoredProcedure(paramScene);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    sceneListCollection = this.DataManager.SceneManager.FetchAllScenes(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(sceneListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = sceneListCollection;
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

            #region FindScene(Scene)
            /// <summary>
            /// This method finds a 'Scene' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Scene' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindScene(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Scene scene = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindSceneStoredProcedure findSceneProc = null;

                    // verify the first parameters is a 'Scene'.
                    if (parameters[0].ObjectValue as Scene != null)
                    {
                        // Get SceneParameter
                        Scene paramScene = (Scene) parameters[0].ObjectValue;

                        // verify paramScene exists
                        if(paramScene != null)
                        {
                            // Now create findSceneProc from SceneWriter
                            // The DataWriter converts the 'Scene'
                            // to the SqlParameter[] array needed to find a 'Scene'.
                            findSceneProc = SceneWriter.CreateFindSceneStoredProcedure(paramScene);
                        }

                        // Verify findSceneProc exists
                        if(findSceneProc != null)
                        {
                            // Execute Find Stored Procedure
                            scene = this.DataManager.SceneManager.FindScene(findSceneProc, dataConnector);

                            // if dataObject exists
                            if(scene != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = scene;
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

            #region InsertScene (Scene)
            /// <summary>
            /// This method inserts a 'Scene' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Scene' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertScene(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Scene scene = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertSceneStoredProcedure insertSceneProc = null;

                    // verify the first parameters is a(n) 'Scene'.
                    if (parameters[0].ObjectValue as Scene != null)
                    {
                        // Create Scene Parameter
                        scene = (Scene) parameters[0].ObjectValue;

                        // verify scene exists
                        if(scene != null)
                        {
                            // Now create insertSceneProc from SceneWriter
                            // The DataWriter converts the 'Scene'
                            // to the SqlParameter[] array needed to insert a 'Scene'.
                            insertSceneProc = SceneWriter.CreateInsertSceneStoredProcedure(scene);
                        }

                        // Verify insertSceneProc exists
                        if(insertSceneProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.SceneManager.InsertScene(insertSceneProc, dataConnector);
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

            #region UpdateScene (Scene)
            /// <summary>
            /// This method updates a 'Scene' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Scene' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateScene(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Scene scene = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateSceneStoredProcedure updateSceneProc = null;

                    // verify the first parameters is a(n) 'Scene'.
                    if (parameters[0].ObjectValue as Scene != null)
                    {
                        // Create Scene Parameter
                        scene = (Scene) parameters[0].ObjectValue;

                        // verify scene exists
                        if(scene != null)
                        {
                            // Now create updateSceneProc from SceneWriter
                            // The DataWriter converts the 'Scene'
                            // to the SqlParameter[] array needed to update a 'Scene'.
                            updateSceneProc = SceneWriter.CreateUpdateSceneStoredProcedure(scene);
                        }

                        // Verify updateSceneProc exists
                        if(updateSceneProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.SceneManager.UpdateScene(updateSceneProc, dataConnector);

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
