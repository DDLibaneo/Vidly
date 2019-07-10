﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {        
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }

        // Ids dos MembershipTypes no Banco
        public static readonly byte Unknown = 0;

        public static readonly byte PayAsYouGo = 1;

        public static readonly byte Monthly = 2;

        public static readonly byte Quarterly = 3;

        public static readonly byte Yearly = 4;
    }
}