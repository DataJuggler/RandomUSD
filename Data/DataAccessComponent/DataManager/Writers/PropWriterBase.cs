

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

    #region class PropWriterBase
    /// <summary>
    /// This class is used for converting a 'Prop' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class PropWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Prop prop)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='prop'>The 'Prop' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Prop prop)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (prop != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", prop.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeletePropStoredProcedure(Prop prop)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteProp'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Prop_Delete'.
            /// </summary>
            /// <param name="prop">The 'Prop' to Delete.</param>
            /// <returns>An instance of a 'DeletePropStoredProcedure' object.</returns>
            public static DeletePropStoredProcedure CreateDeletePropStoredProcedure(Prop prop)
            {
                // Initial Value
                DeletePropStoredProcedure deletePropStoredProcedure = new DeletePropStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deletePropStoredProcedure.Parameters = CreatePrimaryKeyParameter(prop);

                // return value
                return deletePropStoredProcedure;
            }
            #endregion

            #region CreateFindPropStoredProcedure(Prop prop)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindPropStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Prop_Find'.
            /// </summary>
            /// <param name="prop">The 'Prop' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindPropStoredProcedure CreateFindPropStoredProcedure(Prop prop)
            {
                // Initial Value
                FindPropStoredProcedure findPropStoredProcedure = null;

                // verify prop exists
                if(prop != null)
                {
                    // Instanciate findPropStoredProcedure
                    findPropStoredProcedure = new FindPropStoredProcedure();

                    // Now create parameters for this procedure
                    findPropStoredProcedure.Parameters = CreatePrimaryKeyParameter(prop);
                }

                // return value
                return findPropStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Prop prop)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new prop.
            /// </summary>
            /// <param name="prop">The 'Prop' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Prop prop)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[3];
                SqlParameter param = null;

                // verify propexists
                if(prop != null)
                {
                    // Create [CreateText] parameter
                    param = new SqlParameter("@CreateText", prop.CreateText);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Name] parameter
                    param = new SqlParameter("@Name", prop.Name);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [TransformText] parameter
                    param = new SqlParameter("@TransformText", prop.TransformText);

                    // set parameters[2]
                    parameters[2] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertPropStoredProcedure(Prop prop)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertPropStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Prop_Insert'.
            /// </summary>
            /// <param name="prop"The 'Prop' object to insert</param>
            /// <returns>An instance of a 'InsertPropStoredProcedure' object.</returns>
            public static InsertPropStoredProcedure CreateInsertPropStoredProcedure(Prop prop)
            {
                // Initial Value
                InsertPropStoredProcedure insertPropStoredProcedure = null;

                // verify prop exists
                if(prop != null)
                {
                    // Instanciate insertPropStoredProcedure
                    insertPropStoredProcedure = new InsertPropStoredProcedure();

                    // Now create parameters for this procedure
                    insertPropStoredProcedure.Parameters = CreateInsertParameters(prop);
                }

                // return value
                return insertPropStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Prop prop)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing prop.
            /// </summary>
            /// <param name="prop">The 'Prop' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Prop prop)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[4];
                SqlParameter param = null;

                // verify propexists
                if(prop != null)
                {
                    // Create parameter for [CreateText]
                    param = new SqlParameter("@CreateText", prop.CreateText);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", prop.Name);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [TransformText]
                    param = new SqlParameter("@TransformText", prop.TransformText);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", prop.Id);
                    parameters[3] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdatePropStoredProcedure(Prop prop)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdatePropStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Prop_Update'.
            /// </summary>
            /// <param name="prop"The 'Prop' object to update</param>
            /// <returns>An instance of a 'UpdatePropStoredProcedure</returns>
            public static UpdatePropStoredProcedure CreateUpdatePropStoredProcedure(Prop prop)
            {
                // Initial Value
                UpdatePropStoredProcedure updatePropStoredProcedure = null;

                // verify prop exists
                if(prop != null)
                {
                    // Instanciate updatePropStoredProcedure
                    updatePropStoredProcedure = new UpdatePropStoredProcedure();

                    // Now create parameters for this procedure
                    updatePropStoredProcedure.Parameters = CreateUpdateParameters(prop);
                }

                // return value
                return updatePropStoredProcedure;
            }
            #endregion

            #region CreateFetchAllPropsStoredProcedure(Prop prop)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllPropsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Prop_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllPropsStoredProcedure' object.</returns>
            public static FetchAllPropsStoredProcedure CreateFetchAllPropsStoredProcedure(Prop prop)
            {
                // Initial value
                FetchAllPropsStoredProcedure fetchAllPropsStoredProcedure = new FetchAllPropsStoredProcedure();

                // return value
                return fetchAllPropsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
