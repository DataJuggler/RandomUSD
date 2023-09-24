

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using Microsoft.Data.SqlClient;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Writers
{

    #region class SceneWriterBase
    /// <summary>
    /// This class is used for converting a 'Scene' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class SceneWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Scene scene)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='scene'>The 'Scene' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Scene scene)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (scene != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", scene.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteSceneStoredProcedure(Scene scene)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteScene'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Scene_Delete'.
            /// </summary>
            /// <param name="scene">The 'Scene' to Delete.</param>
            /// <returns>An instance of a 'DeleteSceneStoredProcedure' object.</returns>
            public static DeleteSceneStoredProcedure CreateDeleteSceneStoredProcedure(Scene scene)
            {
                // Initial Value
                DeleteSceneStoredProcedure deleteSceneStoredProcedure = new DeleteSceneStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteSceneStoredProcedure.Parameters = CreatePrimaryKeyParameter(scene);

                // return value
                return deleteSceneStoredProcedure;
            }
            #endregion

            #region CreateFindSceneStoredProcedure(Scene scene)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindSceneStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Scene_Find'.
            /// </summary>
            /// <param name="scene">The 'Scene' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindSceneStoredProcedure CreateFindSceneStoredProcedure(Scene scene)
            {
                // Initial Value
                FindSceneStoredProcedure findSceneStoredProcedure = null;

                // verify scene exists
                if(scene != null)
                {
                    // Instanciate findSceneStoredProcedure
                    findSceneStoredProcedure = new FindSceneStoredProcedure();

                    // Now create parameters for this procedure
                    findSceneStoredProcedure.Parameters = CreatePrimaryKeyParameter(scene);
                }

                // return value
                return findSceneStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Scene scene)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new scene.
            /// </summary>
            /// <param name="scene">The 'Scene' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Scene scene)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[2];
                SqlParameter param = null;

                // verify sceneexists
                if(scene != null)
                {
                    // Create [Name] parameter
                    param = new SqlParameter("@Name", scene.Name);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Text] parameter
                    param = new SqlParameter("@Text", scene.Text);

                    // set parameters[1]
                    parameters[1] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertSceneStoredProcedure(Scene scene)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertSceneStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Scene_Insert'.
            /// </summary>
            /// <param name="scene"The 'Scene' object to insert</param>
            /// <returns>An instance of a 'InsertSceneStoredProcedure' object.</returns>
            public static InsertSceneStoredProcedure CreateInsertSceneStoredProcedure(Scene scene)
            {
                // Initial Value
                InsertSceneStoredProcedure insertSceneStoredProcedure = null;

                // verify scene exists
                if(scene != null)
                {
                    // Instanciate insertSceneStoredProcedure
                    insertSceneStoredProcedure = new InsertSceneStoredProcedure();

                    // Now create parameters for this procedure
                    insertSceneStoredProcedure.Parameters = CreateInsertParameters(scene);
                }

                // return value
                return insertSceneStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Scene scene)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing scene.
            /// </summary>
            /// <param name="scene">The 'Scene' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Scene scene)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[3];
                SqlParameter param = null;

                // verify sceneexists
                if(scene != null)
                {
                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", scene.Name);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Text]
                    param = new SqlParameter("@Text", scene.Text);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", scene.Id);
                    parameters[2] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateSceneStoredProcedure(Scene scene)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateSceneStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Scene_Update'.
            /// </summary>
            /// <param name="scene"The 'Scene' object to update</param>
            /// <returns>An instance of a 'UpdateSceneStoredProcedure</returns>
            public static UpdateSceneStoredProcedure CreateUpdateSceneStoredProcedure(Scene scene)
            {
                // Initial Value
                UpdateSceneStoredProcedure updateSceneStoredProcedure = null;

                // verify scene exists
                if(scene != null)
                {
                    // Instanciate updateSceneStoredProcedure
                    updateSceneStoredProcedure = new UpdateSceneStoredProcedure();

                    // Now create parameters for this procedure
                    updateSceneStoredProcedure.Parameters = CreateUpdateParameters(scene);
                }

                // return value
                return updateSceneStoredProcedure;
            }
            #endregion

            #region CreateFetchAllScenesStoredProcedure(Scene scene)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllScenesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Scene_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllScenesStoredProcedure' object.</returns>
            public static FetchAllScenesStoredProcedure CreateFetchAllScenesStoredProcedure(Scene scene)
            {
                // Initial value
                FetchAllScenesStoredProcedure fetchAllScenesStoredProcedure = new FetchAllScenesStoredProcedure();

                // return value
                return fetchAllScenesStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
