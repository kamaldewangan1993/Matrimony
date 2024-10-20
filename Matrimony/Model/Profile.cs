using System;
using System.Collections.Generic;

namespace Matrimony.Model;

public partial class Profile
{
    public int ProfileId { get; set; }

    public int? UserId { get; set; }

    public string? Name { get; set; }

    public string? Dob { get; set; }

    public int? PaternalGotra { get; set; }

    public int? MaternalGotra { get; set; }

    public string? BirthPlace { get; set; }

    public string? BirthTime { get; set; }

    public int? Rashi { get; set; }

    public int? Caste { get; set; }

    public int? BloodGroup { get; set; }

    public int? BodyType { get; set; }

    public int? Complexion { get; set; }

    public string? Weight { get; set; }

    public string? Height { get; set; }

    public bool? Manglik { get; set; }

    public int? MaritalStatus { get; set; }

    public string? Hobby { get; set; }

    public int? Diet { get; set; }

    public bool? Smoking { get; set; }

    public bool? Drinking { get; set; }

    public string? Education { get; set; }

    public int? Occupation { get; set; }

    public string? CompanyName { get; set; }

    public string? Designation { get; set; }

    public string? JobLocation { get; set; }

    public long? MonthlyIncome { get; set; }

    public string? AboutMySelf { get; set; }

    public string? FatherName { get; set; }

    public int? FatherOccupation { get; set; }

    public string? MotherName { get; set; }

    public int? MotherOccupation { get; set; }

    public int? NoOfBrothers { get; set; }

    public int? NoOfBrothersMarried { get; set; }

    public int? NoOfSisters { get; set; }

    public int? NoOfSistersMarried { get; set; }

    public int? FamilyStatus { get; set; }

    public int? FamilyType { get; set; }

    public string? AboutMyFamily { get; set; }

    public string? Images { get; set; }
}
