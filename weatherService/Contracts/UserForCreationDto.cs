using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts;

public class UserForCreationDto
{
    public UserForCreationDto(string name, DateTime dateOfBirth, string address)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        Address = address;
    }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Date of birth is required")]
    public DateTime DateOfBirth { get; set; }
    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }

}