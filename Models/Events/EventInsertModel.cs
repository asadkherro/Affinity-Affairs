namespace Models.Events
{
    public record EventInsertModel
    {
        public string Name { get; init; } = string.Empty;
        public string Location { get; init; } = string.Empty;
        public string Description {  get; init; } = string.Empty;   
        public DateTime Date { get; init; }
    }
}
