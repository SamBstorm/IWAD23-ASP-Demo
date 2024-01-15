using ASP_Exo03_Scaffolding.Models;

namespace ASP_Exo03_Scaffolding.Handlers
{
    public static class Mapper
    {
        public static SleepListItemViewModel ToListItem (this SleepModel entity)
        {
            if (entity is null) return null;
            return new SleepListItemViewModel()
            {
                Id = entity.Id,
                RecordDate = entity.SleepStart.Date,
                Duration = entity.SleepEnd - entity.SleepStart,
                HaveDreamed = entity.HaveDreamed
            };
        }
    }
}
