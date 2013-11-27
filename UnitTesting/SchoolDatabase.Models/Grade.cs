﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace StudentsDatabase.Models
{
    [DataContract]
    public class Grade
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember(IsRequired = true)]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public double Value { get; set; }
    }
}