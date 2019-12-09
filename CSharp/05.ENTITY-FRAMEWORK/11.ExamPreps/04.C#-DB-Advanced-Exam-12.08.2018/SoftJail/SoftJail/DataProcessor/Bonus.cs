namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Bonus
    {
        public static string ReleasePrisoner(SoftJailDbContext context, int prisonerId)
        {
            var target = context.Prisoners.Find(prisonerId);

            if (target.ReleaseDate != null)
            {
                target.ReleaseDate = DateTime.Now;
                target.CellId = default;
                context.SaveChanges();

                return $"Prisoner {target.FullName} released";
            }

            else
            {
                return $"Prisoner {target.FullName} is sentenced to life";
            }
        }
    }
}
