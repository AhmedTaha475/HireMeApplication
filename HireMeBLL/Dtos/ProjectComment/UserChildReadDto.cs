namespace HireMeBLL { 
    public record UserChildReadDto
    {
        public string? Id { get; init; }
        public string? FName { get; init; }
        public string? LName { get; init; }
        public byte[]? img { get; init; }
    }
}