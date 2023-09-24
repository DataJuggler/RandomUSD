
#region using statements

using ApplicationLogicComponent.Controllers;
using ApplicationLogicComponent.DataOperations;
using DataAccessComponent.DataManager;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

#endregion

namespace DataGateway
{

    #region class Gateway
    /// <summary>
    /// This class is used to manage DataOperations
    /// between the client and the DataAccessComponent.
    /// Do not change the method name or the parameters for the
    /// code generated methods or they will be recreated the next 
    /// time you code generate with DataTier.Net. If you need additional
    /// parameters passed to a method either create an override or
    /// add or set properties to the temp object that is passed in.
    /// </summary>
    public class Gateway
    {

        #region Private Variables
        private ApplicationController appController;
        private string connectionName;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a Gateway object.
        /// </summary>
        public Gateway(string connectionName = "")
        {
            // store the ConnectionName
            this.ConnectionName = connectionName;

            // Perform Initializations for this object
            Init();
        }
        #endregion

        #region Methods
        
            #region DeleteMaterial(int id, Material tempMaterial = null)
            /// <summary>
            /// This method is used to delete Material objects.
            /// </summary>
            /// <param name="id">Delete the Material with this id</param>
            /// <param name="tempMaterial">Pass in a tempMaterial to perform a custom delete.</param>
            public bool DeleteMaterial(int id, Material tempMaterial = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempMaterial does not exist
                    if (tempMaterial == null)
                    {
                        // create a temp Material
                        tempMaterial = new Material();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempMaterial.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.MaterialController.Delete(tempMaterial);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteProp(int id, Prop tempProp = null)
            /// <summary>
            /// This method is used to delete Prop objects.
            /// </summary>
            /// <param name="id">Delete the Prop with this id</param>
            /// <param name="tempProp">Pass in a tempProp to perform a custom delete.</param>
            public bool DeleteProp(int id, Prop tempProp = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempProp does not exist
                    if (tempProp == null)
                    {
                        // create a temp Prop
                        tempProp = new Prop();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempProp.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.PropController.Delete(tempProp);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region DeleteScene(int id, Scene tempScene = null)
            /// <summary>
            /// This method is used to delete Scene objects.
            /// </summary>
            /// <param name="id">Delete the Scene with this id</param>
            /// <param name="tempScene">Pass in a tempScene to perform a custom delete.</param>
            public bool DeleteScene(int id, Scene tempScene = null)
            {
                // initial value
                bool deleted = false;
        
                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempScene does not exist
                    if (tempScene == null)
                    {
                        // create a temp Scene
                        tempScene = new Scene();
                    }
        
                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempScene.UpdateIdentity(id);
                    }
        
                    // perform the delete
                    deleted = this.AppController.ControllerManager.SceneController.Delete(tempScene);
                }
        
                // return value
                return deleted;
            }
            #endregion
        
            #region ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            /// <summary>
            /// This method Executes a Non Query StoredProcedure
            /// </summary>
            public PolymorphicObject ExecuteNonQuery(string procedureName, SqlParameter[] sqlParameters)
            {
                // initial value
                PolymorphicObject returnValue = new PolymorphicObject();

                // locals
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // create the parameters
                PolymorphicObject procedureNameParameter = new PolymorphicObject();
                PolymorphicObject sqlParametersParameter = new PolymorphicObject();

                // if the procedureName exists
                if (!String.IsNullOrEmpty(procedureName))
                {
                    // Create an instance of the SystemMethods object
                    SystemMethods systemMethods = new SystemMethods();

                    // setup procedureNameParameter
                    procedureNameParameter.Name = "ProcedureName";
                    procedureNameParameter.Text = procedureName;

                    // setup sqlParametersParameter
                    sqlParametersParameter.Name = "SqlParameters";
                    sqlParametersParameter.ObjectValue = sqlParameters;

                    // Add these parameters to the parameters
                    parameters.Add(procedureNameParameter);
                    parameters.Add(sqlParametersParameter);

                    // get the dataConnector
                    DataAccessComponent.DataManager.DataConnector dataConnector = GetDataConnector();

                    // Execute the query
                    returnValue = systemMethods.ExecuteNonQuery(parameters, dataConnector);
                }

                // return value
                return returnValue;
            }
            #endregion

            #region FindMaterial(int id, Material tempMaterial = null)
            /// <summary>
            /// This method is used to find 'Material' objects.
            /// </summary>
            /// <param name="id">Find the Material with this id</param>
            /// <param name="tempMaterial">Pass in a tempMaterial to perform a custom find.</param>
            public Material FindMaterial(int id, Material tempMaterial = null)
            {
                // initial value
                Material material = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempMaterial does not exist
                    if (tempMaterial == null)
                    {
                        // create a temp Material
                        tempMaterial = new Material();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempMaterial.UpdateIdentity(id);
                    }

                    // perform the find
                    material = this.AppController.ControllerManager.MaterialController.Find(tempMaterial);
                }

                // return value
                return material;
            }
            #endregion

            #region FindProp(int id, Prop tempProp = null)
            /// <summary>
            /// This method is used to find 'Prop' objects.
            /// </summary>
            /// <param name="id">Find the Prop with this id</param>
            /// <param name="tempProp">Pass in a tempProp to perform a custom find.</param>
            public Prop FindProp(int id, Prop tempProp = null)
            {
                // initial value
                Prop prop = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempProp does not exist
                    if (tempProp == null)
                    {
                        // create a temp Prop
                        tempProp = new Prop();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempProp.UpdateIdentity(id);
                    }

                    // perform the find
                    prop = this.AppController.ControllerManager.PropController.Find(tempProp);
                }

                // return value
                return prop;
            }
            #endregion

            #region FindScene(int id, Scene tempScene = null)
            /// <summary>
            /// This method is used to find 'Scene' objects.
            /// </summary>
            /// <param name="id">Find the Scene with this id</param>
            /// <param name="tempScene">Pass in a tempScene to perform a custom find.</param>
            public Scene FindScene(int id, Scene tempScene = null)
            {
                // initial value
                Scene scene = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // if the tempScene does not exist
                    if (tempScene == null)
                    {
                        // create a temp Scene
                        tempScene = new Scene();
                    }

                    // if the id is set
                    if (id > 0)
                    {
                        // set the primary key
                        tempScene.UpdateIdentity(id);
                    }

                    // perform the find
                    scene = this.AppController.ControllerManager.SceneController.Find(tempScene);
                }

                // return value
                return scene;
            }
            #endregion

            #region GetDataConnector()
            /// <summary>
            /// This method (safely) returns the Data Connector from the
            /// AppController.DataBridget.DataManager.DataConnector
            /// </summary>
            private DataConnector GetDataConnector()
            {
                // initial value
                DataConnector dataConnector = null;

                // if the AppController exists
                if (this.AppController != null)
                {
                    // return the DataConnector from the AppController
                    dataConnector = this.AppController.GetDataConnector();
                }

                // return value
                return dataConnector;
            }
            #endregion

            #region GetLastException()
            /// <summary>
            /// This method returns the last Exception from the AppController if one exists.
            /// Always test for null before refeferencing the Exception returned as it will be null 
            /// if no errors were encountered.
            /// </summary>
            /// <returns></returns>
            public Exception GetLastException()
            {
                // initial value
                Exception exception = null;

                // If the AppController object exists
                if (this.HasAppController)
                {
                    // return the Exception from the AppController
                    exception = this.AppController.Exception;

                    // Set to null after the exception is retrieved so it does not return again
                    this.AppController.Exception = null;
                }

                // return value
                return exception;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perform Initializations for this object.
            /// </summary>
            private void Init()
            {
                // Create Application Controller
                this.AppController = new ApplicationController(ConnectionName);
            }
            #endregion

            #region LoadMaterials(Material tempMaterial = null)
            /// <summary>
            /// This method loads a collection of 'Material' objects.
            /// </summary>
            public List<Material> LoadMaterials(Material tempMaterial = null)
            {
                // initial value
                List<Material> materials = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    materials = this.AppController.ControllerManager.MaterialController.FetchAll(tempMaterial);
                }

                // return value
                return materials;
            }
            #endregion

            #region LoadProps(Prop tempProp = null)
            /// <summary>
            /// This method loads a collection of 'Prop' objects.
            /// </summary>
            public List<Prop> LoadProps(Prop tempProp = null)
            {
                // initial value
                List<Prop> props = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    props = this.AppController.ControllerManager.PropController.FetchAll(tempProp);
                }

                // return value
                return props;
            }
            #endregion

            #region LoadScenes(Scene tempScene = null)
            /// <summary>
            /// This method loads a collection of 'Scene' objects.
            /// </summary>
            public List<Scene> LoadScenes(Scene tempScene = null)
            {
                // initial value
                List<Scene> scenes = null;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the load
                    scenes = this.AppController.ControllerManager.SceneController.FetchAll(tempScene);
                }

                // return value
                return scenes;
            }
            #endregion

            #region SaveMaterial(ref Material material)
            /// <summary>
            /// This method is used to save 'Material' objects.
            /// </summary>
            /// <param name="material">The Material to save.</param>
            public bool SaveMaterial(ref Material material)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.MaterialController.Save(ref material);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveProp(ref Prop prop)
            /// <summary>
            /// This method is used to save 'Prop' objects.
            /// </summary>
            /// <param name="prop">The Prop to save.</param>
            public bool SaveProp(ref Prop prop)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.PropController.Save(ref prop);
                }

                // return value
                return saved;
            }
            #endregion

            #region SaveScene(ref Scene scene)
            /// <summary>
            /// This method is used to save 'Scene' objects.
            /// </summary>
            /// <param name="scene">The Scene to save.</param>
            public bool SaveScene(ref Scene scene)
            {
                // initial value
                bool saved = false;

                // if the AppController exists
                if (this.HasAppController)
                {
                    // perform the save
                    saved = this.AppController.ControllerManager.SceneController.Save(ref scene);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            /// <summary>
            /// This property gets or sets the value for 'AppController'.
            /// </summary>
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ConnectionName
            /// <summary>
            /// This property gets or sets the value for 'ConnectionName'.
            /// </summary>
            public string ConnectionName
            {
                get { return connectionName; }
                set { connectionName = value; }
            }
            #endregion
            
            #region HasAppController
            /// <summary>
            /// This property returns true if this object has an 'AppController'.
            /// </summary>
            public bool HasAppController
            {
                get
                {
                    // initial value
                    bool hasAppController = (this.AppController != null);

                    // return value
                    return hasAppController;
                }
            }
            #endregion

            #region HasConnectionName
            /// <summary>
            /// This property returns true if the 'ConnectionName' exists.
            /// </summary>
            public bool HasConnectionName
            {
                get
                {
                    // initial value
                    bool hasConnectionName = (!String.IsNullOrEmpty(this.ConnectionName));
                    
                    // return value
                    return hasConnectionName;
                }
            }
            #endregion
            
        #endregion

    }
    #endregion

}

