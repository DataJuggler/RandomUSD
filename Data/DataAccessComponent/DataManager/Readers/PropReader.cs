

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class PropReader
    /// <summary>
    /// This class loads a single 'Prop' object or a list of type <Prop>.
    /// </summary>
    public class PropReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Prop' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Prop' DataObject.</returns>
            public static Prop Load(DataRow dataRow)
            {
                // Initial Value
                Prop prop = new Prop();

                // Create field Integers
                int createTextfield = 0;
                int idfield = 1;
                int namefield = 2;
                int transformTextfield = 3;

                try
                {
                    // Load Each field
                    prop.CreateText = DataHelper.ParseString(dataRow.ItemArray[createTextfield]);
                    prop.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    prop.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    prop.TransformText = DataHelper.ParseString(dataRow.ItemArray[transformTextfield]);
                }
                catch
                {
                }

                // return value
                return prop;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Prop' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Prop Collection.</returns>
            public static List<Prop> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Prop> props = new List<Prop>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Prop' from rows
                        Prop prop = Load(row);

                        // Add this object to collection
                        props.Add(prop);
                    }
                }
                catch
                {
                }

                // return value
                return props;
            }
            #endregion

        #endregion

    }
    #endregion

}
