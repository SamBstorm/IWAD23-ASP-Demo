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

        public static SleepDetailsViewModel ToDetails (this SleepModel entity)
        {
            if (entity is null) return null;
            return new SleepDetailsViewModel()
            {
                Id = entity.Id,
                SleepStart = entity.SleepStart,
                SleepEnd = entity.SleepEnd,
                HaveDreamed = entity.HaveDreamed,
                IsNightmare = entity.IsNightmare,
                DreamDescription = entity.DreamDescription,
                HaveSnored = entity.HaveSnored
            };
        }

        public static SleepModel ToData (this SleepCreateForm entity)
        {
            if (entity is null) return null;
            return new SleepModel()
            {
                SleepStart = entity.SleepStart,
                SleepEnd = entity.SleepEnd,
                HaveDreamed = entity.HaveDreamed,
                IsNightmare = entity.IsNightmare,
                DreamDescription = entity.DreamDescription,
                HaveSnored = entity.HaveSnored
            };
        }

        public static SleepEditForm ToEdit (this SleepModel entity) {
            if (entity is null) return null;
            return new SleepEditForm(){
                Id = entity.Id,
                HaveDreamed = entity.HaveDreamed,
                IsNightmare = entity.IsNightmare,
                DreamDescription = entity.DreamDescription
            };
        }

        public static SleepModel ToData (this SleepEditForm entity) {
            if (entity is null) return null;
            return new SleepModel()
            {
                Id = entity.Id,
                HaveDreamed = entity.HaveDreamed,
                IsNightmare = entity.IsNightmare,
                DreamDescription = entity.DreamDescription
            };
        }

        public static SleepDeleteForm ToDelete (this SleepModel entity)
        {
            if (entity is null) return null;
            return new SleepDeleteForm()
            {
                Id = entity.Id,
                SleepStart = entity.SleepStart
            };
        }
    }
}
