using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.Dtos.Visitor
{
    public class CreateVisitorDto
    {
         [Required]
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public string PhotoPath { get; set; } = string.Empty;

    [Required]
    public VisitorType VisitorType { get; set; } = VisitorType.Customer;
    }
}