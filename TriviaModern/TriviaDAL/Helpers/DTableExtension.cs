﻿using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TriviaGame;
using System.Linq;
using System.Web;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System;


namespace TriviaGame
{
    public static class DTableExtension
    {
        private static Dictionary<Type, IList<PropertyInfo>> typeDictionary = new Dictionary<Type, IList<PropertyInfo>>();
       
        public static IList<PropertyInfo> GetPropertiesForType<T>()
        {
            var type = typeof(T);
            if (!typeDictionary.ContainsKey(typeof(T)))
            {
                typeDictionary.Add(type, type.GetProperties().ToList());
            }
            return typeDictionary[type];

        }

        public static IList<T> ToAnyList<T>(this DataTable table) where T : new()
        {

            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            IList<T> result = new List<T>();

            foreach (var row in table.Rows)
            {
                var item = CreateObjFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }

            return result;
        }

        public static T CreateObjFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {

            var _myObject = Activator.CreateInstance<T>(); // reflection api 
            foreach (var property in properties) // ili typeof(T).GetProperties()
            {
                if (!object.Equals(row[property.Name], DBNull.Value))
                {
                    property.SetValue(_myObject, row[property.Name], null);
                }
            }
            return _myObject;
        }

    }
}
