using Backend.Domain.Enum;
using System;

namespace Backend.Domain.Entities.ExerciseType
{
    public class ExerciseTypeProperty
    {
        public Guid Id { get; set; }
        public ExerciseTypePropertyType ExerciseTypePropertyType { get; set; }
        public string Value { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }

    }

    public class BarPosition : ExerciseTypeProperty
    {
        public new ExerciseTypePropertyType ExerciseTypePropertyType => ExerciseTypePropertyType.BarPosition;
    }

    public class BarType : ExerciseTypeProperty
    {
        public new ExerciseTypePropertyType ExerciseTypePropertyType => ExerciseTypePropertyType.BarType;
    }

    public class Grip : ExerciseTypeProperty
    {
        public new ExerciseTypePropertyType ExerciseTypePropertyType => ExerciseTypePropertyType.Grip;
    }

    public class Tempo : ExerciseTypeProperty
    {
        public new ExerciseTypePropertyType ExerciseTypePropertyType => ExerciseTypePropertyType.Tempo;
    }

    public class LoadAccomodation : ExerciseTypeProperty
    {
        public new ExerciseTypePropertyType ExerciseTypePropertyType => ExerciseTypePropertyType.LoadAccomodation;
    }
    public class Category : ExerciseTypeProperty
    {
        public new ExerciseTypePropertyType ExerciseTypePropertyType => ExerciseTypePropertyType.Category;
    }

    public class Equipment : ExerciseTypeProperty
    {
        public new ExerciseTypePropertyType ExerciseTypePropertyType => ExerciseTypePropertyType.Equipment;
    }

    public class RangeOfMotion : ExerciseTypeProperty
    {
        public new ExerciseTypePropertyType ExerciseTypePropertyType => ExerciseTypePropertyType.RangeOfMotion;
    }

    public class Stance : ExerciseTypeProperty
    {
        public new ExerciseTypePropertyType ExerciseTypePropertyType => ExerciseTypePropertyType.Stance;
    }

}
