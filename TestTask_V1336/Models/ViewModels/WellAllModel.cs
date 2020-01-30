using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TestTask_V1336.Models;

namespace TestTask_V1336.Models.ViewModels
{
    public class WellAllModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WellAllModel()
        {

        }

        [Display(Name = "Идентификатор скважины")]
        public int ID { get; set; }

        [Display(Name = "Название скважины")]
        public string Name { get; set; }

        [Display(Name = "Название группы скважин (куста)")]
        public string Group { get; set; }

        [Display(Name = "Название месторождения")]
        public string Field { get; set; }

        [Display(Name = "Название ЦДНГ")]
        public string Factory { get; set; }

        [Display(Name = "Идентификатор установленного контроллера")]
        public int ControllerID { get; set; }

        [Display(Name = "Тип эксплуатации")]
        public Well.OperationTypeEnum OperTypes { get; set; }
    }
}