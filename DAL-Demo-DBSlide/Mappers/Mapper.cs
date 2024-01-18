using DAL_Demo_DBSlide.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL_Demo_DBSlide.Mappers
{
    internal static class Mapper
    {
        public static Student ToStudent(this IDataRecord record)
        {
            if (record is null) return null;
            return new Student()
            {
                Student_Id = (int)record["Student_id"],
                First_name = (string)record["First_name"],
                Last_name = (string)record["Last_name"],
                Birth_date = (DateTime)record["Birth_date"],
                Login = (string)record["Login"],
                Section_id = (int)record["Section_id"],
                Year_result = (record["Year_result"] == DBNull.Value) ? null : (int?)record["Year_result"],
                Course_id = (string)record["Course_id"]
            };
        }

        public static Section ToSection(this IDataRecord record)
        {
            if (record is null) return null;
            return new Section()
            {
                Section_id = (int)record["Section_id"],
                Section_name = (record["Section_name"] == DBNull.Value)? null : (string?)record["Section_name"],
                Delegate_id = (record["Delegate_id"] == DBNull.Value)? null : (int?)record["Delegate_id"]
            };
        }
    }
}
