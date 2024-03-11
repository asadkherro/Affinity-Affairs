namespace Models.Images
{
    public class ImagesModel
    {
        public Guid Id { get; init; }
        public Guid EntityId { get; init; }
        public byte[] Data { get; init; }
    }
}
