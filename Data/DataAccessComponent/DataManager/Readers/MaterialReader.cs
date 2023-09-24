

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class MaterialReader
    /// <summary>
    /// This class loads a single 'Material' object or a list of type <Material>.
    /// </summary>
    public class MaterialReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Material' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Material' DataObject.</returns>
            public static Material Load(DataRow dataRow)
            {
                // Initial Value
                Material material = new Material();

                // Create field Integers
                int idfield = 0;
                int materialTypefield = 1;
                int pathfield = 2;
                int textfield = 3;
                int titlefield = 4;

                try
                {
                    // Load Each field
                    material.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    material.MaterialType = (MaterialTypeEnum) DataHelper.ParseInteger(dataRow.ItemArray[materialTypefield], 0);
                    material.Path = DataHelper.ParseString(dataRow.ItemArray[pathfield]);
                    material.Text = DataHelper.ParseString(dataRow.ItemArray[textfield]);
                    material.Title = DataHelper.ParseString(dataRow.ItemArray[titlefield]);
                }
                catch
                {
                }

                // return value
                return material;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Material' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Material Collection.</returns>
            public static List<Material> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Material> materials = new List<Material>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Material' from rows
                        Material material = Load(row);

                        // Add this object to collection
                        materials.Add(material);
                    }
                }
                catch
                {
                }

                // return value
                return materials;
            }
            #endregion

        #endregion

    }
    #endregion

}
