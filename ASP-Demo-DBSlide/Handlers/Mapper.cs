using ASP_Demo_DBSlide.Models;
using BLL_Demo_DBSlide.Entities;

namespace ASP_Demo_DBSlide.Handlers
{
    public static class Mapper
    {
        #region Student
        public static StudentListItemViewModel ToListItem(this Student entity)
        {
            if (entity is null) return null;
            return new StudentListItemViewModel()
            {
                Student_id = entity.Student_id,
                First_name = entity.First_name,
                Last_name = entity.Last_name
            };
        }

        public static Student ToBLL(this StudentCreateForm entity)
        {
            if (entity is null) return null;
            return new Student(
                0,
                entity.First_name,
                entity.Last_name,
                entity.Birth_date,
                "",
                entity.Section_id,
                null,
                "0"
                );
        }
        #endregion
        #region Section
        public static SectionListItemViewModel ToListItem (this Section entity)
        {
            if (entity is null) return null;
            return new SectionListItemViewModel()
            {
                Section_id = entity.Section_id,
                Section_name = entity.Section_name
            };
        }
        #endregion
    }
}
