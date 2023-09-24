

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

    #region class MaterialWriterBase
    /// <summary>
    /// This class is used for converting a 'Material' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class MaterialWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Material material)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='material'>The 'Material' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Material material)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (material != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", material.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteMaterialStoredProcedure(Material material)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteMaterial'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Material_Delete'.
            /// </summary>
            /// <param name="material">The 'Material' to Delete.</param>
            /// <returns>An instance of a 'DeleteMaterialStoredProcedure' object.</returns>
            public static DeleteMaterialStoredProcedure CreateDeleteMaterialStoredProcedure(Material material)
            {
                // Initial Value
                DeleteMaterialStoredProcedure deleteMaterialStoredProcedure = new DeleteMaterialStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteMaterialStoredProcedure.Parameters = CreatePrimaryKeyParameter(material);

                // return value
                return deleteMaterialStoredProcedure;
            }
            #endregion

            #region CreateFindMaterialStoredProcedure(Material material)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindMaterialStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Material_Find'.
            /// </summary>
            /// <param name="material">The 'Material' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindMaterialStoredProcedure CreateFindMaterialStoredProcedure(Material material)
            {
                // Initial Value
                FindMaterialStoredProcedure findMaterialStoredProcedure = null;

                // verify material exists
                if(material != null)
                {
                    // Instanciate findMaterialStoredProcedure
                    findMaterialStoredProcedure = new FindMaterialStoredProcedure();

                    // Now create parameters for this procedure
                    findMaterialStoredProcedure.Parameters = CreatePrimaryKeyParameter(material);
                }

                // return value
                return findMaterialStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Material material)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new material.
            /// </summary>
            /// <param name="material">The 'Material' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Material material)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[4];
                SqlParameter param = null;

                // verify materialexists
                if(material != null)
                {
                    // Create [MaterialType] parameter
                    param = new SqlParameter("@MaterialType", material.MaterialType);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Path] parameter
                    param = new SqlParameter("@Path", material.Path);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [Text] parameter
                    param = new SqlParameter("@Text", material.Text);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [Title] parameter
                    param = new SqlParameter("@Title", material.Title);

                    // set parameters[3]
                    parameters[3] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertMaterialStoredProcedure(Material material)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertMaterialStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Material_Insert'.
            /// </summary>
            /// <param name="material"The 'Material' object to insert</param>
            /// <returns>An instance of a 'InsertMaterialStoredProcedure' object.</returns>
            public static InsertMaterialStoredProcedure CreateInsertMaterialStoredProcedure(Material material)
            {
                // Initial Value
                InsertMaterialStoredProcedure insertMaterialStoredProcedure = null;

                // verify material exists
                if(material != null)
                {
                    // Instanciate insertMaterialStoredProcedure
                    insertMaterialStoredProcedure = new InsertMaterialStoredProcedure();

                    // Now create parameters for this procedure
                    insertMaterialStoredProcedure.Parameters = CreateInsertParameters(material);
                }

                // return value
                return insertMaterialStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Material material)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing material.
            /// </summary>
            /// <param name="material">The 'Material' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Material material)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[5];
                SqlParameter param = null;

                // verify materialexists
                if(material != null)
                {
                    // Create parameter for [MaterialType]
                    param = new SqlParameter("@MaterialType", material.MaterialType);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Path]
                    param = new SqlParameter("@Path", material.Path);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Text]
                    param = new SqlParameter("@Text", material.Text);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Title]
                    param = new SqlParameter("@Title", material.Title);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", material.Id);
                    parameters[4] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateMaterialStoredProcedure(Material material)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateMaterialStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Material_Update'.
            /// </summary>
            /// <param name="material"The 'Material' object to update</param>
            /// <returns>An instance of a 'UpdateMaterialStoredProcedure</returns>
            public static UpdateMaterialStoredProcedure CreateUpdateMaterialStoredProcedure(Material material)
            {
                // Initial Value
                UpdateMaterialStoredProcedure updateMaterialStoredProcedure = null;

                // verify material exists
                if(material != null)
                {
                    // Instanciate updateMaterialStoredProcedure
                    updateMaterialStoredProcedure = new UpdateMaterialStoredProcedure();

                    // Now create parameters for this procedure
                    updateMaterialStoredProcedure.Parameters = CreateUpdateParameters(material);
                }

                // return value
                return updateMaterialStoredProcedure;
            }
            #endregion

            #region CreateFetchAllMaterialsStoredProcedure(Material material)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllMaterialsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Material_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllMaterialsStoredProcedure' object.</returns>
            public static FetchAllMaterialsStoredProcedure CreateFetchAllMaterialsStoredProcedure(Material material)
            {
                // Initial value
                FetchAllMaterialsStoredProcedure fetchAllMaterialsStoredProcedure = new FetchAllMaterialsStoredProcedure();

                // return value
                return fetchAllMaterialsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
