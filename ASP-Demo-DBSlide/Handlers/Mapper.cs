using ASP_Demo_DBSlide.Models;
using BLL_Demo_DBSlide.Entities;

namespace ASP_Demo_DBSlide.Handlers
{
    public static class Mapper
    {
        public static StudentListItemViewModel ToListItem(this Student entity) {
            if (entity is null) return null;
            return new StudentListItemViewModel()
            {
                Student_id = entity.Student_id,
                First_name = entity.First_name,
                Last_name = entity.Last_name
            };
        }
    }
}
