

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class SceneReader
    /// <summary>
    /// This class loads a single 'Scene' object or a list of type <Scene>.
    /// </summary>
    public class SceneReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Scene' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Scene' DataObject.</returns>
            public static Scene Load(DataRow dataRow)
            {
                // Initial Value
                Scene scene = new Scene();

                // Create field Integers
                int idfield = 0;
                int namefield = 1;
                int textfield = 2;

                try
                {
                    // Load Each field
                    scene.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    scene.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    scene.Text = DataHelper.ParseString(dataRow.ItemArray[textfield]);
                }
                catch
                {
                }

                // return value
                return scene;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Scene' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Scene Collection.</returns>
            public static List<Scene> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Scene> scenes = new List<Scene>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Scene' from rows
                        Scene scene = Load(row);

                        // Add this object to collection
                        scenes.Add(scene);
                    }
                }
                catch
                {
                }

                // return value
                return scenes;
            }
            #endregion

        #endregion

    }
    #endregion

}
