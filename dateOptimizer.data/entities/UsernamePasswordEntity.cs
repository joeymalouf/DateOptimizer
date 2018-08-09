using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dateOptimizer.data.entities
{
    public class UsernamePasswordEntity
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}