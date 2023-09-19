using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public ICollection<GeoPoint> GeoPoints { get; set; }
}