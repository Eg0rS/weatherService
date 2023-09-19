using System;
using System.Collections.Generic;

namespace Contracts;

public class UserDto
{
    public UserDto(Guid id, string name, DateTime dateOfBirth, string address, ICollection<GeoPointDto> geoPoints)
    {
        Id = id;
        Name = name;
        DateOfBirth = dateOfBirth;
        Address = address;
        GeoPoints = geoPoints;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public ICollection<GeoPointDto> GeoPoints { get; set; }
}