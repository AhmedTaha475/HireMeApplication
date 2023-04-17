namespace HireMeBLL.Dtos.ProjectComment
{
    public record ClientChildReadDto
    {
        public string Id { get; init; }
        public string FName { get; init; }
        public string LName { get; init; }
        public byte[] img { get; init; }
    }
}