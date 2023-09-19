namespace Contracts;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public ICollection<GeoPointDto> GeoPoints { get; set; }
}