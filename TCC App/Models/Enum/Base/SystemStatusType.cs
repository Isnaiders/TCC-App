﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TCC_App.Models.Enum.Base
{
    public enum SystemStatusType : int
    {
        [Display(Name = "Desconhecido")]
        Unknown = 0,
        [Display(Name = "Ativo")]
        Active = 1,
        [Display(Name = "Bloqueado")]
        Blocked = 2,
        [Display(Name = "Pendente de Aprovação")]
        PendingApproval = 3,
        [Display(Name = "Removido")]
        Removed = 4
    }
}