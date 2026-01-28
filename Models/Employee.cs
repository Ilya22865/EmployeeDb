using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tmds.DBus.Protocol;

namespace ProjectPractika.Models;

public class Employee {
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Department { get; set; }
    public decimal Salary { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public DateTimeOffset DateOfEmployment { get; set; }

}