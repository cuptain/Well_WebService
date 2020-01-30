using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TestTask_V1336.Models;

namespace TestTask_V1336.Models.ViewModels
{
    public class WellSearchModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WellSearchModel()
        {

        }
        [Display(Name = "Идентификатор скважины")]
        public string ID { get; set; }

        [Display(Name = "Идентификатор контроллера")]
        public string ControllerID { get; set; }

        [Display(Name = "Тип эксплуатации")]
        public Well.OperationTypeEnum OperTypes { get; set; }
    }
}