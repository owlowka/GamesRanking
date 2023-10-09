namespace GamesRanking.Data.Entities
{
    public abstract record class EntityBase : IEntity
    {
        public int? Id { get; set; }

    }
}
