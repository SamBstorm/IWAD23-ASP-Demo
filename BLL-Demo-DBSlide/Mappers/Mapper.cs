using System;
using System.Collections.Generic;
using System.Text;
using BLL = BLL_Demo_DBSlide.Entities;
using DAL = DAL_Demo_DBSlide.Entities;

namespace BLL_Demo_DBSlide.Mappers
{
    internal static class Mapper
    {
        #region Student
        public static BLL.Student ToBLL(this DAL.Student entity)
        {
            if (entity is null) return null;
            return new BLL.Student(
                entity.Student_Id,
                entity.First_name,
                entity.Last_name,
                entity.Birth_date,
                entity.Login,
                entity.Section_id,
                entity.Year_result,
                entity.Course_id);
        }

        public static DAL.Student ToDAL(this BLL.Student entity)
        {
            if (entity is null) return null;
            return new DAL.Student()
            {
                Student_Id = entity.Student_id,
                First_name = entity.First_name,
                Last_name = entity.Last_name,
                Birth_date = entity.Birth_date,
                Login = entity.Login,
                Section_id = entity.Section_id,
                Year_result = entity.Year_result,
                Course_id = entity.Course_id
            };
        }
        #endregion
        #region Section
        public static BLL.Section ToBLL(this DAL.Section entity)
        {
            if (entity is null) return null;
            return new BLL.Section(
                entity.Section_id,
                entity.Section_name,
                entity.Delegate_id
                );
        }

        public static DAL.Section ToDAL(this BLL.Section entity)
        {
            if (entity is null) return null;
            return new DAL.Section()
            {
                Section_id = entity.Section_id,
                Section_name = entity.Section_name,
                Delegate_id = entity.Delegate_id
            };
        }
        #endregion
    }
}
